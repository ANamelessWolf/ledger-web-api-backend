WITH A AS (
SELECT 
s.id, s.last_payment_date, s.price, s.currency_id, sph.subscription_id,
c.conversion AS exchange_rate 
FROM db_ledger.subscription s 
LEFT JOIN db_ledger.currency c ON c.id = s.currency_id 
LEFT JOIN db_ledger.subscription_payment_history sph 
ON s.id = sph.subscription_id 
WHERE s.last_payment_date = sph.payment_date) 
SELECT 
NULL AS id, A.id AS subscription_id, 
A.last_payment_date AS payment_date,
A.price AS total, 
A.exchange_rate
FROM A
WHERE A.subscription_id IS NULL;


DROP PROCEDURE GetMonthlySubscription;
CREATE PROCEDURE GetMonthlySubscription(
IN _month VARCHAR(2),
IN _year VARCHAR(4) 
)
BEGIN
    WITH A AS(
        SELECT
            CONCAT(_year,"-",_month,'-01') start_date,
            DATE_ADD(s.last_payment_date, INTERVAL (pf.months + pf.years * 12) MONTH) next_payment_date,
            s.price * c.conversion price_mxn,
            w.name wallet,
            s.*
        FROM
            db_ledger.subscription s
        LEFT JOIN db_ledger.payment_frequency pf ON
            pf.id = s.payment_frequency_id
        LEFT JOIN db_ledger.currency c ON
            c.id = s.currency_id
        LEFT JOIN db_ledger.wallet w ON
            w.id = s.wallet_id
        WHERE
            s.active = 1)
        SELECT
            A.id,
            A.wallet_id,
            A.name,
            A.wallet,
            A.price,
            A.price_mxn,
            A.charge_day,
            CASE
                WHEN A.next_payment_date > LAST_DAY(start_date) THEN A.last_payment_date
                ELSE A.next_payment_date
            END pay_date
        FROM
            A
        WHERE
            A.next_payment_date BETWEEN CAST(start_date AS DATE) AND LAST_DAY(start_date)
            OR
        A.last_payment_date BETWEEN CAST(start_date AS DATE) AND LAST_DAY(start_date);
END;


CALL GetMonthlySubscription('10', '2023');





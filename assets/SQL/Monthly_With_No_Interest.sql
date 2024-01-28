SELECT * FROM `VW_Monthly_With_No_Interest_Summary`;
SELECT * FROM `VW_Monthly_With_No_Interest`;


CREATE VIEW `VW_Monthly_With_No_Interest` AS
SELECT
    mwni.id,
    cc.id credit_card_id,
    w.id wallet_id,
    w.name credit_card,
    e.id AS expense_id,
    e.description AS expense,
    e.buy_date AS transaction_date,
    e.total initial_charge,
    CONCAT('$ ', FORMAT(e.total, 2, 'es_MX')) initial_charge_formatted,
    e.total / mwni.months AS monthly_fee,
    CONCAT('$ ', FORMAT(e.total / mwni.months, 2, 'es_MX')) AS monthly_fee_formatted,
    CONCAT(paid_months, ' de ', months) payments,
    e.total-(e.total / mwni.months)* paid_months AS remaining_debt,
    CONCAT('$ ', FORMAT(e.total-(e.total / mwni.months)* paid_months, 2, 'es_MX')) AS remaining_debt_formatted
FROM
    db_ledger.monthly_with_no_interest mwni
LEFT JOIN db_ledger.expense e ON
    e.id = mwni .expense_id
LEFT JOIN db_ledger.credit_card cc ON
    cc.id = mwni.credit_card_id
LEFT JOIN db_ledger.wallet w ON
    w.id = cc.wallet_id
WHERE
    archived = 0
ORDER BY
    w.name,
    mwni.start_date ;

DROP VIEW `VW_Monthly_With_No_Interest_Summary`;
CREATE VIEW `VW_Monthly_With_No_Interest_Summary` AS
WITH summary AS (
SELECT
    vw.credit_card_id,
    vw.wallet_id,
    vw.credit_card,
    sum(initial_charge) AS initial_charge,
    sum(monthly_fee) AS monthly_fee,
    sum(remaining_debt) AS remaining_debt
FROM
    `VW_Monthly_With_No_Interest` vw
GROUP BY
    vw.credit_card_id,
    vw.wallet_id,
    vw.credit_card
UNION
SELECT
    NULL AS credit_card_id,
    NULL AS wallet_id,
    'Total' AS credit_card,
    sum(initial_charge) AS initial_charge,
    sum(monthly_fee) AS monthly_fee,
    sum(remaining_debt) AS remaining_debt
FROM
    `VW_Monthly_With_No_Interest` vw )
SELECT
    s.credit_card_id,
    s.wallet_id,
    s.credit_card,
    s.initial_charge,
    CONCAT('$ ', FORMAT(s.initial_charge, 2, 'es_MX')) initial_charge_formatted,
    s.monthly_fee,
    CONCAT('$ ', FORMAT(s.monthly_fee, 2, 'es_MX')) monthly_fee_formatted,
    s.remaining_debt,
    CONCAT('$ ', FORMAT(s.remaining_debt, 2, 'es_MX')) remaining_debt_formatted
FROM
    summary s;
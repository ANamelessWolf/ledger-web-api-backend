-- CREATE VIEW VW_CREDITCARD_PAYMENTS AS
WITH A AS(
SELECT
    cc.id credit_card_id,
    ccp.period_cut_date,
    ccp.period_due_date,
    CASE WHEN ccp.payment_date IS NULL THEN CAST(CONCAT(1900, '-', '01', '-', '01') AS date) ELSE  CAST(ccp.payment_date AS date) END AS last_payment_date,
    CONCAT(MONTHNAME(period_cut_date), ' ' ,YEAR(ccp.period_cut_date)) period,
    CASE WHEN ccp.payment_total IS NULL THEN 0 ELSE ccp.payment_total END AS payment_total
FROM
    credit_card cc
LEFT JOIN financing_entity fe ON
    fe.id = cc.entity_id
LEFT JOIN wallet w ON
    w.id = cc.wallet_id
LEFT JOIN credit_card_payment ccp ON 
    ccp.credit_card_id = cc.id 
    )
SELECT
   A.credit_card_id, 
   A.period_cut_date, 
   A.period_due_date, 
   A.period,
   MAX(A.last_payment_date) last_payment_date,    
   SUM(A.payment_total) payment_total
FROM
    A
GROUP BY A.credit_card_id, A.period;
    

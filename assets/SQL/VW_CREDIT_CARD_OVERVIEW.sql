DROP VIEW VW_CREDIT_CARD_OVERVIEW;
CREATE VIEW VW_CREDIT_CARD_OVERVIEW AS
SELECT 
cc.id,
w.id wallet_id,
fe.id entity_id,
cccp.name card_name,
fe.name entity,
cc.credit,
cc.use_credit,
cccp.current_cut_date,
cccp.next_cut_date,
cccp.current_period,
cccp.spent_days,
cccp.current_payment,
cccp.payment_period,
vcp.last_payment_date,
CASE 
    WHEN cc.use_credit<=0 THEN 'NOT REQUIRED'
    WHEN current_date() <= cccp.current_payment AND vcp.payment_total IS NULL THEN 'OVERDUE'
    WHEN current_date() <= cccp.current_payment AND vcp.payment_total IS NOT NULL THEN 'PAID'
    WHEN vcp.last_payment_date > cccp.next_payment AND vcp.payment_total IS NOT NULL THEN 'PAID'
    WHEN vcp.last_payment_date < cccp.next_payment AND  vcp.last_payment_date < cccp.next_cut_date AND vcp.payment_total IS NOT NULL THEN 'NOT REQUIRED'
ELSE 'PENDING' END payment_status,
cccp.next_payment,
CASE WHEN current_date() <= current_payment THEN cccp.days_to_due ELSE ABS(datediff(next_payment, current_date())) END days_to_due,
cc.expiration,
cc.card_type,
cc.ending,
cc.color
FROM 
credit_card cc 
LEFT JOIN vw_credit_card_current_periods cccp ON cccp.id = cc.id
LEFT JOIN vw_creditcard_payments vcp ON vcp.credit_card_id = cc.id AND cccp.payment_period = vcp.period 
LEFT JOIN financing_entity fe ON fe.id = cc.entity_id
LEFT JOIN wallet w ON w.id = cc.wallet_id;

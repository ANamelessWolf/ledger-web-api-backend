DROP VIEW VW_CREDIT_CARD_CURRENT_PERIODS;
CREATE VIEW VW_CREDIT_CARD_CURRENT_PERIODS AS
WITH A AS(
SELECT 
vw.*,
ABS(DATEDIFF(vw.today_date, vw.prev_month_cut_date)) AS A_DIF,
ABS(DATEDIFF(vw.today_date, vw.next_month_cut_date)) AS C_DIF
-- ABS(DATEDIFF(CAST(CONCAT(2024, '-', '03', '-', '02') AS date), vw.prev_month_cut_date)) AS A_DIF,
-- ABS(DATEDIFF(CAST(CONCAT(2024, '-', '03', '-', '02') AS date), vw.next_month_cut_date)) AS C_DIF
FROM db_ledger.vw_credit_card_periods vw)
SELECT 
A.credit_card_id id,
A.name,
A.cut_day,
A.due_day,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN A.current_month_cut_date
    WHEN A.cut_day >= 15 THEN A.prev_month_cut_date
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN A.current_month_cut_date
    ELSE A.prev_month_cut_date
END current_cut_date,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN date_add(A.current_month_cut_date, INTERVAL 1 MONTH)
    WHEN A.cut_day >= 15 THEN date_add(A.prev_month_cut_date, INTERVAL 1 MONTH)
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN date_add(A.current_month_cut_date, INTERVAL 1 MONTH)
    ELSE date_add(A.prev_month_cut_date, INTERVAL 1 MONTH)
END next_cut_date,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN ABS(DATEDIFF(date_add(A.current_month_cut_date, INTERVAL 1 MONTH), A.today_date))
    WHEN A.cut_day >= 15 THEN ABS(DATEDIFF(date_add(A.prev_month_cut_date, INTERVAL 1 MONTH), A.today_date))
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN ABS(DATEDIFF(date_add(A.current_month_cut_date, INTERVAL 1 MONTH), A.today_date))
    ELSE ABS(DATEDIFF(date_add(A.prev_month_cut_date, INTERVAL 1 MONTH), A.today_date))
END spent_days,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN A.next_cut_period
    WHEN A.cut_day >= 15 THEN A.current_cut_period
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN A.current_cut_period
    ELSE A.prev_cut_period
END current_period,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN A.next_month_pay_date
    WHEN A.cut_day >= 15 THEN A.current_month_pay_date
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN A.next_month_pay_date
    ELSE A.current_month_pay_date
END current_payment,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN ABS(DATEDIFF(A.next_month_pay_date, A.today_date))
    WHEN A.cut_day >= 15 THEN ABS(DATEDIFF(A.current_month_pay_date, A.today_date))
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN ABS(DATEDIFF(A.next_month_pay_date, A.today_date))
    ELSE ABS(DATEDIFF(A.current_month_pay_date, A.today_date))
END days_to_due,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN date_add(A.next_month_pay_date, INTERVAL 1 MONTH)
    WHEN A.cut_day >= 15 THEN date_add(A.current_month_pay_date, INTERVAL 1 MONTH)
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN date_add(A.next_month_pay_date, INTERVAL 1 MONTH)
    ELSE date_add(A.current_month_pay_date, INTERVAL 1 MONTH)
END next_payment,
CASE 
    WHEN A.cut_day >= 15 AND A.C_DIF <= 30 THEN A.current_pay_period
    WHEN A.cut_day >= 15 THEN A.prev_pay_period
    WHEN A.cut_day < 15 AND A.C_DIF <= 30 THEN A.prev_pay_period
    ELSE A.prev2_pay_period
END payment_period
FROM A;
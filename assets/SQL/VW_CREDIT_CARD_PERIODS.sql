DROP VIEW VW_CREDIT_CARD_PERIODS;
CREATE VIEW VW_CREDIT_CARD_PERIODS  AS
WITH A AS(
SELECT
    cc.id credit_card_id,
    w.name,
    cc.cut_day,
    cc.due_day,
    curdate() today_date,
    CAST(CONCAT(YEAR(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', MONTH(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', cc.cut_day) AS date) AS prev_month_cut_date,
    CAST(CONCAT(YEAR(curdate()), '-', MONTH(curdate()), '-', cc.cut_day) AS date) AS current_month_cut_date,
    CAST(CONCAT(YEAR(DATE_ADD(curdate(), INTERVAL 1 MONTH)), '-', MONTH(DATE_ADD(curdate(), INTERVAL 1 MONTH)), '-', cc.cut_day) AS date) AS next_month_cut_date,
    CAST(CONCAT(YEAR(DATE_SUB(curdate(), INTERVAL 2 MONTH)), '-', MONTH(DATE_SUB(curdate(), INTERVAL 2 MONTH)), '-', cc.due_day) AS date) AS prev2_month_pay_date,
    CAST(CONCAT(YEAR(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', MONTH(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', cc.due_day) AS date) AS prev_month_pay_date,
    CAST(CONCAT(YEAR(curdate()), '-', MONTH(curdate()), '-', cc.due_day) AS date) AS current_month_pay_date,
    CAST(CONCAT(YEAR(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', MONTH(DATE_SUB(curdate(), INTERVAL 1 MONTH)), '-', cc.due_day) AS date) AS next_month_pay_date
FROM
    credit_card cc
LEFT JOIN wallet w ON
    w.id = cc.wallet_id 
)
SELECT
   A.*,
   CONCAT(MONTHNAME(prev_month_cut_date), ' ' ,YEAR(prev_month_cut_date)) prev_cut_period,
   CONCAT(MONTHNAME(current_month_cut_date), ' ' ,YEAR(current_month_cut_date)) current_cut_period,
   CONCAT(MONTHNAME(next_month_cut_date), ' ' ,YEAR(next_month_cut_date)) next_cut_period,
   CONCAT(MONTHNAME(prev2_month_pay_date), ' ' ,YEAR(prev2_month_pay_date)) prev2_pay_period,
   CONCAT(MONTHNAME(prev_month_pay_date), ' ' ,YEAR(prev_month_pay_date)) prev_pay_period,
   CONCAT(MONTHNAME(current_month_pay_date), ' ' ,YEAR(current_month_pay_date)) current_pay_period
FROM
    A
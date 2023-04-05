CREATE OR ALTER VIEW OperCodeV AS
SELECT 
  Oper_ID
, Oper_Login
, CD_Code
, CD_Stauts
FROM dbo.operator
join dbo.codes on operator.Oper_ID = codes.CD_OperID
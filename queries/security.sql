CREATE ROLE reportReader;

GRANT SELECT ON vwPublicCustomerOrders TO reportReader;
GRANT SELECT ON vwOrderTotals TO reportReader;

CREATE USER reportUser WITHOUT LOGIN;
ALTER ROLE reportReader ADD MEMBER reportUser;

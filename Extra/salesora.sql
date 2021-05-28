CREATE TABLE CUSTOMERS(
	CUST_ID VARCHAR2(8) PRIMARY KEY,
 	PWD VARCHAR2(8) CHECK(LENGTH(PWD) >= 4), 
	EMAIL VARCHAR2(24) NOT NULL,
	CREDIT NUMBER(8,2) CHECK(CREDIT >= 0));

CREATE TABLE PRODUCTS(
	PNO INT  PRIMARY KEY, 
	PRICE NUMBER(8,2) NOT NULL,
	STOCK INT CHECK(STOCK >= 0));

CREATE TABLE ORDERS(
	ORD_NO INT PRIMARY KEY, 
	ORD_DATE DATE, 
	CUST_ID VARCHAR2(8) REFERENCES CUSTOMERS(CUST_ID), 
	PNO INT REFERENCES PRODUCTS(PNO), 
	QTY INT CHECK(QTY >= 0));

CREATE TABLE COUNTERS(
	CTR_NAME VARCHAR2(8) PRIMARY KEY, 
	CUR_VAL INT NOT NULL);


INSERT INTO CUSTOMERS VALUES ('CU101', 'PW101', 'JOHN@DOE.COM', 5000);
INSERT INTO CUSTOMERS VALUES ('CU102', 'PW102', 'JILL@SMITH.NET', 6000);
INSERT INTO CUSTOMERS VALUES ('CU103', 'PW103', 'JACK@SMITH.NET', 7000);
INSERT INTO CUSTOMERS VALUES ('CU104', 'PW104', 'JANE@DOE.COM', 8000);

INSERT INTO PRODUCTS VALUES (101, 350, 10);
INSERT INTO PRODUCTS VALUES (102, 975, 20);
INSERT INTO PRODUCTS VALUES (103, 845,30);
INSERT INTO PRODUCTS VALUES (104, 1025, 40);
INSERT INTO PRODUCTS VALUES (105, 700, 50);

INSERT INTO ORDERS VALUES(1001, '12-Jan-2020', 'CU102', 101, 5);
INSERT INTO ORDERS VALUES(1002, '25-Jan-2020', 'CU103', 102, 10);
INSERT INTO ORDERS VALUES(1003, '08-Feb-2020', 'CU102', 102, 12);
INSERT INTO ORDERS VALUES(1004, '21-Mar-2020', 'CU101', 103, 3);
INSERT INTO ORDERS VALUES(1005, '19-Mar-2020', 'CU103', 104, 15);
INSERT INTO ORDERS VALUES(1006, '11-Apr-2020', 'CU104', 105, 12);

INSERT INTO COUNTERS VALUES('products', 5);
INSERT INTO COUNTERS VALUES('orders', 6);

COMMIT;

CREATE VIEW INVOICES AS 
    SELECT ORD_NO, ORD_DATE, CUST_ID, ORDERS.PNO, QTY, PRICE*QTY AS AMT 
    FROM ORDERS, PRODUCTS 
    WHERE ORDERS.PNO = PRODUCTS.PNO;


CREATE OR REPLACE PROCEDURE PLACE_ORDER(
    CUSTOMER VARCHAR2, 
    PRODUCT INT, 
    QUANTITY INT, 
    ORDID OUT INT) AS
BEGIN
    UPDATE COUNTERS SET CUR_VAL=CUR_VAL+1 WHERE CTR_NAME='orders';
    SELECT CUR_VAL+1000 INTO ORDID FROM COUNTERS WHERE CTR_NAME='orders';
    INSERT INTO ORDERS VALUES(ORDID, SYSDATE, CUSTOMER, PRODUCT, QUANTITY);
    COMMIT;
    EXCEPTION
    WHEN OTHERS THEN
    BEGIN
        ROLLBACK;
        RAISE;
    END;
END;
/

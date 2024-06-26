-- Insertar datos en la tabla CLIENTE
BEGIN
    FOR CLIENTE IN 1..10 LOOP
        INSERT INTO CLIENTE (CLIENTE_ID, NOMBRE, CLAVE, MAIL, ESTATUS)
        VALUES (CLIENTE, 'CLIENTE ' || CLIENTE, 'CLIE_' || CLIENTE, 'cliente' || CLIENTE || '@clie.com', 'ACTIVO');
    END LOOP;
    UPDATE CLIENTE SET ESTATUS = 'INACTIVO' WHERE CLIENTE_ID IN (3, 7, 10);
    COMMIT;
END;
/

-- Insertar datos en la tabla PRODUCTO
BEGIN
    FOR PRODUCTO IN 1..15 LOOP
        INSERT INTO PRODUCTO (PRODUCTO_ID, DESCRIPCION, COSTO_UNITARIO, ESTATUS)
        VALUES (PRODUCTO, 'PRODUCTO ' || PRODUCTO, ROUND(DBMS_RANDOM.VALUE(1, 9999), 2), 'ACTIVO');
    END LOOP;
    UPDATE PRODUCTO SET ESTATUS = 'INACTIVO' WHERE PRODUCTO_ID IN (5, 11, 13);
    COMMIT;
END;
/

-- Insertar datos en la tabla VENTA
BEGIN
    FOR VENTA IN 1..10 LOOP
        INSERT INTO VENTA (VENTA_ID, FECHA, CLIENTE_ID, ESTATUS)
        VALUES (VENTA, SYSDATE - VENTA, VENTA, 'COMPLETADO');
    END LOOP;
    COMMIT;
END;
/

-- Insertar datos en la tabla DETALLE_VENTA
BEGIN
    FOR DETALLE IN 1..30 LOOP
        INSERT INTO DETALLE_VENTA (VENTA_ID, PRODUCTO_ID, CANTIDAD, DESCUENTO, TOTAL)
        VALUES (MOD(DETALLE, 10) + 1, MOD(DETALLE, 15) + 1, TRUNC(DBMS_RANDOM.VALUE(1, 10)), ROUND(DBMS_RANDOM.VALUE(0, 50), 2), ROUND(DBMS_RANDOM.VALUE(10, 500), 2));
    END LOOP;
    COMMIT;
END;
/

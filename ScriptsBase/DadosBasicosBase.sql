/*Insere Operadoras*/
INSERT INTO Operadoras (codigo, nome, categoria, preco) values 
(14,'Oi',       'Celular', 1),
(15,'Vivo',     'Celular', 2),
(41,'Tim',      'Celular', 4),
(25,'GVT',      'Fixo',    2),
(21,'Embratel', 'Fixo',    1)
GO

/*Insere Contatos*/
INSERT INTO Contatos (id, nome, data, telefone, codigoOperadora) values 
(1, 'Caue',   GETDATE(), '9999-9999', 15),
(2, 'Caio',   GETDATE(), '9999-9988', 41),
(3, 'Sandra', GETDATE(), '9999-9977', 14),
(4, 'Bento',  GETDATE(), '9999-9966', 15)
GO
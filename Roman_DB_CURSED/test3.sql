--
-- Script was generated by Devart dbForge Studio 2019 for MySQL, Version 8.2.23.0
-- Product home page: http://www.devart.com/dbforge/mysql/studio
-- Script date 28.05.2021 16:41:52
-- Server version: 5.7.33-log
-- Client version: 4.1
--

-- 
-- Disable foreign keys
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Set SQL mode
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

DROP DATABASE IF EXISTS test3;

CREATE DATABASE IF NOT EXISTS test3
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Set default database
--
USE test3;

--
-- Create table `resspec`
--
CREATE TABLE IF NOT EXISTS resspec (
  ResSpecId int(11) NOT NULL AUTO_INCREMENT,
  ResSpecName text NOT NULL,
  PRIMARY KEY (ResSpecId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `measure`
--
CREATE TABLE IF NOT EXISTS measure (
  MeasureId int(11) NOT NULL AUTO_INCREMENT,
  MeasureName text NOT NULL,
  PRIMARY KEY (MeasureId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 17,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `techmap`
--
CREATE TABLE IF NOT EXISTS techmap (
  TechMapId int(11) NOT NULL AUTO_INCREMENT,
  TechMapName text NOT NULL,
  PRIMARY KEY (TechMapId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `nom`
--
CREATE TABLE IF NOT EXISTS nom (
  NomId int(11) NOT NULL AUTO_INCREMENT,
  MeasureId int(11) NOT NULL,
  TechMapId int(11) DEFAULT NULL,
  NomName text NOT NULL,
  NomDesc text DEFAULT NULL,
  ResSpecId int(11) DEFAULT NULL,
  PRIMARY KEY (NomId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 31,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create index `IX_Relationship10` on table `nom`
--
ALTER TABLE nom
ADD INDEX IX_Relationship10 (TechMapId);

--
-- Create foreign key
--
ALTER TABLE nom
ADD CONSTRAINT FK_nom_measure_MeasureId FOREIGN KEY (MeasureId)
REFERENCES measure (MeasureId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE nom
ADD CONSTRAINT FK_nom_resspec_ResSpecId FOREIGN KEY (ResSpecId)
REFERENCES resspec (ResSpecId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE nom
ADD CONSTRAINT FK_nom_techmap_TechMapId FOREIGN KEY (TechMapId)
REFERENCES techmap (TechMapId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create table `resspecnoms`
--
CREATE TABLE IF NOT EXISTS resspecnoms (
  NomId int(11) NOT NULL,
  ResSpecId int(11) NOT NULL,
  NomCount decimal(20, 10) NOT NULL,
  PRIMARY KEY (NomId, ResSpecId)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 862,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create foreign key
--
ALTER TABLE resspecnoms
ADD CONSTRAINT FK_resspecnoms_nom_NomId FOREIGN KEY (NomId)
REFERENCES nom (NomId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE resspecnoms
ADD CONSTRAINT Relationship7 FOREIGN KEY (ResSpecId)
REFERENCES resspec (ResSpecId);

--
-- Create table `subdivision`
--
CREATE TABLE IF NOT EXISTS subdivision (
  SubDivisionId int(11) NOT NULL AUTO_INCREMENT,
  SubDivisionName text NOT NULL,
  PRIMARY KEY (SubDivisionId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `prodstage`
--
CREATE TABLE IF NOT EXISTS prodstage (
  TechMapId int(11) NOT NULL,
  ProdStagId int(11) NOT NULL AUTO_INCREMENT,
  ProdStageName text NOT NULL,
  ProdStageDuration int(11) NOT NULL,
  SubDivisionId int(11) NOT NULL,
  ProdStageNextStage int(11) DEFAULT NULL,
  ProdStageIndex int(11) NOT NULL,
  PRIMARY KEY (ProdStagId),
  UNIQUE INDEX UK_prodstage_ProdStagId (ProdStagId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
AVG_ROW_LENGTH = 1638,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create index `UK_prodstage_TechMapId` on table `prodstage`
--
ALTER TABLE prodstage
ADD INDEX UK_prodstage_TechMapId (TechMapId);

--
-- Create foreign key
--
ALTER TABLE prodstage
ADD CONSTRAINT FK_ProdStage_Subdivision_SubdivisionId FOREIGN KEY (SubDivisionId)
REFERENCES subdivision (SubDivisionId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE prodstage
ADD CONSTRAINT FK_prodstage_prodstage_ProdStagId FOREIGN KEY (ProdStageNextStage)
REFERENCES prodstage (ProdStagId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE prodstage
ADD CONSTRAINT FK_prodstage_techmap_TechMapId FOREIGN KEY (TechMapId)
REFERENCES techmap (TechMapId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create table `orderstatus`
--
CREATE TABLE IF NOT EXISTS orderstatus (
  OrderStatusId int(11) NOT NULL AUTO_INCREMENT,
  OrderStatusCaption text NOT NULL,
  PRIMARY KEY (OrderStatusId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `order`
--
CREATE TABLE IF NOT EXISTS `order` (
  OrderId int(11) NOT NULL AUTO_INCREMENT,
  OrderStatusId int(11) NOT NULL,
  OrderDate datetime NOT NULL,
  NomId int(11) NOT NULL,
  NomCount decimal(20, 10) NOT NULL,
  PRIMARY KEY (OrderId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 3,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create foreign key
--
ALTER TABLE `order`
ADD CONSTRAINT FK_order_nom_NomId FOREIGN KEY (NomId)
REFERENCES nom (NomId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE `order`
ADD CONSTRAINT FK_order_orderstatus_OrderStatusId FOREIGN KEY (OrderStatusId)
REFERENCES orderstatus (OrderStatusId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create table `productionlog`
--
CREATE TABLE IF NOT EXISTS productionlog (
  ProductionLogId int(11) NOT NULL AUTO_INCREMENT,
  ProdStageStartTime datetime NOT NULL,
  ProdStageActualDuration int(11) NOT NULL,
  NomCount decimal(20, 10) DEFAULT NULL,
  OrderId int(11) DEFAULT NULL,
  ProdStagId int(11) DEFAULT NULL,
  TechMapId int(11) DEFAULT NULL,
  PRIMARY KEY (ProductionLogId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create index `IX_Relationship16` on table `productionlog`
--
ALTER TABLE productionlog
ADD INDEX IX_Relationship16 (ProdStagId, TechMapId);

--
-- Create foreign key
--
ALTER TABLE productionlog
ADD CONSTRAINT FK_productionlog_order_OrderId FOREIGN KEY (OrderId)
REFERENCES `order` (OrderId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE productionlog
ADD CONSTRAINT FK_productionlog_prodstage_ProdStagId FOREIGN KEY (ProdStagId)
REFERENCES prodstage (ProdStagId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE productionlog
ADD CONSTRAINT FK_productionlog_prodstage_TechMapId FOREIGN KEY (TechMapId)
REFERENCES prodstage (TechMapId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create table `consumptionlog`
--
CREATE TABLE IF NOT EXISTS consumptionlog (
  NomId int(11) NOT NULL,
  ProductionLogId int(11) NOT NULL,
  NomCount decimal(20, 10) DEFAULT NULL,
  PRIMARY KEY (NomId, ProductionLogId)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create foreign key
--
ALTER TABLE consumptionlog
ADD CONSTRAINT Relationship19 FOREIGN KEY (NomId)
REFERENCES nom (NomId);

--
-- Create foreign key
--
ALTER TABLE consumptionlog
ADD CONSTRAINT Relationship20 FOREIGN KEY (ProductionLogId)
REFERENCES productionlog (ProductionLogId);

--
-- Create table `storage`
--
CREATE TABLE IF NOT EXISTS storage (
  StorageId int(11) NOT NULL AUTO_INCREMENT,
  StorageName text NOT NULL,
  PRIMARY KEY (StorageId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 10,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `storagecontains`
--
CREATE TABLE IF NOT EXISTS storagecontains (
  StorageId int(11) NOT NULL,
  NomId int(11) NOT NULL,
  NumCount decimal(20, 10) NOT NULL,
  PRIMARY KEY (StorageId, NomId)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create foreign key
--
ALTER TABLE storagecontains
ADD CONSTRAINT FK_storagecontains_nom_NomId FOREIGN KEY (NomId)
REFERENCES nom (NomId) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Create foreign key
--
ALTER TABLE storagecontains
ADD CONSTRAINT FK_storagecontains_storage_StorageId FOREIGN KEY (StorageId)
REFERENCES storage (StorageId) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- 
-- Dumping data for table resspec
--
INSERT INTO resspec VALUES
(7, 'Плата'),
(8, 'Корпус'),
(9, 'Плата в сборке'),
(10, 'Калькулятор');

-- 
-- Dumping data for table measure
--
INSERT INTO measure VALUES
(13, 'Кг'),
(14, 'м.'),
(15, 'шт.'),
(16, 'м.кв.');

-- 
-- Dumping data for table techmap
--
INSERT INTO techmap VALUES
(2, 'Производство Платы в сборке'),
(3, 'Производство Корпуса'),
(4, 'Производство Платы'),
(5, 'Производство Калькулятора');

-- 
-- Dumping data for table subdivision
--
INSERT INTO subdivision VALUES
(7, 'Паяльный цех'),
(8, 'Сборочный цех'),
(9, 'Производство корпусов'),
(10, 'Производство печатных плат');

-- 
-- Dumping data for table orderstatus
--
INSERT INTO orderstatus VALUES
(4, 'Выполняется');

-- 
-- Dumping data for table nom
--
INSERT INTO nom VALUES
(9, 13, NULL, 'Хлорное железо', NULL, NULL),
(10, 13, NULL, 'Припой', NULL, NULL),
(11, 16, NULL, 'Текстолит', NULL, NULL),
(12, 13, NULL, 'Пластик', NULL, NULL),
(13, 15, NULL, 'Батарея', NULL, NULL),
(14, 15, NULL, 'Батарейный отсек', NULL, NULL),
(15, 15, NULL, 'Экран', NULL, NULL),
(16, 15, NULL, 'Солнечная панель', NULL, NULL),
(17, 15, NULL, 'Конденсатор 1', NULL, NULL),
(18, 15, NULL, 'Конденсатор 2', NULL, NULL),
(19, 15, NULL, 'Резистор 1', NULL, NULL),
(20, 15, NULL, 'Резистор 2', NULL, NULL),
(21, 15, NULL, 'Диод 1', NULL, NULL),
(22, 15, NULL, 'Диод 2', NULL, NULL),
(23, 15, NULL, 'Кнопка 1', NULL, NULL),
(24, 15, NULL, 'Кнопка 2', NULL, NULL),
(25, 15, NULL, 'Клавиатура', NULL, NULL),
(26, 15, NULL, 'Винт 1\r\n', NULL, NULL),
(27, 15, 4, 'Плата', NULL, 7),
(28, 15, 2, 'Плата в сборке', NULL, 9),
(29, 15, 3, 'Корпус', NULL, 8),
(30, 15, 5, 'Калькулятор', 'Готовый калькулятор', 10);

-- 
-- Dumping data for table prodstage
--
INSERT INTO prodstage VALUES
(4, 1, 'Очистка платы от краски', 239997, 10, 3, 0),
(4, 2, 'Травление', 240000, 10, 1, 0),
(4, 3, 'Лужение', 240000, 10, NULL, 0),
(4, 4, 'Сверление отверстий', 240000, 10, 2, 0),
(4, 5, 'Нанесение краски', 240000, 10, 4, 0),
(4, 6, 'Обрезка текстолита', 240000, 10, NULL, 0),
(3, 7, 'Плавление пластика', 240000, 9, 8, 0),
(3, 8, 'Пресовка пластика в форму', 240000, 9, NULL, 0),
(2, 9, 'Установка компонентов на плату', 240000, 7, NULL, 0),
(5, 10, 'Установка компонентов калькулятора', 240000, 8, NULL, 0);

-- 
-- Dumping data for table `order`
--
INSERT INTO `order` VALUES
(1, 4, '0001-01-01 00:00:00', 30, 1.0000000000),
(2, 4, '0001-01-01 00:00:00', 27, 1.0000000000);

-- 
-- Dumping data for table storage
--
INSERT INTO storage VALUES
(6, 'Склад сырья и материалов'),
(7, 'Склад электроэлементов'),
(8, 'Склад доволнительных элементов'),
(9, 'Склад полуфабрикатов');

-- 
-- Dumping data for table productionlog
--
INSERT INTO productionlog VALUES
(1, '2021-01-09 00:00:00', 0, NULL, NULL, NULL, NULL),
(2, '2021-02-01 00:00:00', 8, NULL, NULL, 1, NULL),
(3, '2021-01-01 00:00:00', 5, NULL, NULL, 6, NULL),
(4, '0001-01-01 00:00:00', 5, NULL, 1, 5, NULL);

-- 
-- Dumping data for table storagecontains
--
INSERT INTO storagecontains VALUES
(6, 26, 1.2000000000);

-- 
-- Dumping data for table resspecnoms
--
INSERT INTO resspecnoms VALUES
(9, 7, 1.0000000000),
(10, 7, 1.0000000000),
(11, 7, 1.0000000000),
(12, 8, 1.0000000000),
(13, 8, 1.0000000000),
(13, 10, 1.0000000000),
(17, 9, 2.0000000000),
(18, 9, 3.0000000000),
(19, 9, 5.0000000000),
(20, 9, 7.0000000000),
(21, 9, 1.0000000000),
(22, 9, 3.0000000000),
(23, 10, 1.0000000000),
(24, 10, 2.0000000000),
(25, 10, 1.0000000000),
(26, 10, 4.0000000000),
(27, 9, 1.0000000000),
(28, 10, 1.0000000000),
(29, 10, 1.0000000000);

-- 
-- Dumping data for table consumptionlog
--
INSERT INTO consumptionlog VALUES
(13, 4, 1.0000000000);

-- 
-- Restore previous SQL mode
-- 
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Enable foreign keys
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;
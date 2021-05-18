﻿--
-- Script was generated by Devart dbForge Studio 2019 for MySQL, Version 8.2.23.0
-- Product home page: http://www.devart.com/dbforge/mysql/studio
-- Script date 19.05.2021 1:57:06
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
-- Create table `nomtype`
--
CREATE TABLE IF NOT EXISTS nomtype (
  NomTypeId int(11) NOT NULL AUTO_INCREMENT,
  NomTypeCaption text NOT NULL,
  PRIMARY KEY (NomTypeId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
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
AUTO_INCREMENT = 13,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `storage`
--
CREATE TABLE IF NOT EXISTS storage (
  StorageId int(11) NOT NULL AUTO_INCREMENT,
  StorageName text NOT NULL,
  PRIMARY KEY (StorageId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `resspec`
--
CREATE TABLE IF NOT EXISTS resspec (
  ResSpecId int(11) NOT NULL AUTO_INCREMENT,
  ResSpecName text NOT NULL,
  PRIMARY KEY (ResSpecId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 16384,
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
AUTO_INCREMENT = 2,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `nom`
--
CREATE TABLE IF NOT EXISTS nom (
  NomId int(11) NOT NULL AUTO_INCREMENT,
  MeasureId int(11) NOT NULL,
  NomTypeId int(11) NOT NULL,
  TechMapId int(11) DEFAULT NULL,
  NomName text NOT NULL,
  NomDesc text DEFAULT NULL,
  ResSpecId int(11) DEFAULT NULL,
  PRIMARY KEY (NomId)
)
ENGINE = INNODB,
AUTO_INCREMENT = 9,
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
ADD CONSTRAINT FK_nom_nomtype_NomTypeId FOREIGN KEY (NomTypeId)
REFERENCES nomtype (NomTypeId) ON DELETE NO ACTION ON UPDATE NO ACTION;

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
-- Create table `resspecnoms`
--
CREATE TABLE IF NOT EXISTS resspecnoms (
  NomId int(11) NOT NULL,
  ResSpecId int(11) NOT NULL,
  NomCount decimal(20, 10) NOT NULL,
  PRIMARY KEY (NomId, ResSpecId)
)
ENGINE = INNODB,
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
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Create table `prodstage`
--
CREATE TABLE IF NOT EXISTS prodstage (
  TechMapId int(11) NOT NULL,
  ProdStagId int(11) NOT NULL AUTO_INCREMENT,
  ProdStageName text NOT NULL,
  ProdStageDuration time NOT NULL,
  SubDivisionId int(11) NOT NULL,
  ProdStageNextStage int(11) DEFAULT NULL,
  PRIMARY KEY (ProdStagId, TechMapId)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

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
AUTO_INCREMENT = 4,
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
-- Dumping data for table nomtype
--
INSERT INTO nomtype VALUES
(3, 'Полуфабрикат'),
(4, 'Сырье'),
(5, 'Готовая продукция');

-- 
-- Dumping data for table measure
--
INSERT INTO measure VALUES
(8, 'Квадратные метры'),
(9, 'Погонный метр'),
(10, 'Шт'),
(11, 'Кг'),
(12, 'См');

-- 
-- Dumping data for table storage
--
INSERT INTO storage VALUES
(4, 'Склад электроэлементов');

-- 
-- Dumping data for table resspec
--
INSERT INTO resspec VALUES
(4, 'Корпус');

-- 
-- Dumping data for table techmap
--
-- Table test3.techmap does not contain any data (it is empty)

-- 
-- Dumping data for table subdivision
--
INSERT INTO subdivision VALUES
(2, 'Изготовление печатных плат'),
(3, 'Цех печатных плат'),
(4, 'Цех изготоволения корпусов'),
(5, 'Цех паяльный'),
(6, 'Цех сборочный');

-- 
-- Dumping data for table orderstatus
--
-- Table test3.orderstatus does not contain any data (it is empty)

-- 
-- Dumping data for table nom
--
INSERT INTO nom VALUES
(7, 11, 4, NULL, 'Пластик1', 'серый пластик для корпусов', NULL);

-- 
-- Dumping data for table storagecontains
--
-- Table test3.storagecontains does not contain any data (it is empty)

-- 
-- Dumping data for table resspecnoms
--
INSERT INTO resspecnoms VALUES
(7, 4, 5.0000000000);

-- 
-- Dumping data for table prodstage
--
-- Table test3.prodstage does not contain any data (it is empty)

-- 
-- Dumping data for table `order`
--
-- Table test3.`order` does not contain any data (it is empty)

-- 
-- Restore previous SQL mode
-- 
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Enable foreign keys
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;
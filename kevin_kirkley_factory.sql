CREATE DATABASE  IF NOT EXISTS `kevin_kirkley_factory` 
USE `kevin_kirkley_factory`;

 SET NAMES utf8 ;


DROP TABLE IF EXISTS `__EFMigrationsHistory`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Engineers`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Engineers` (
  `EngineerId` int(11) NOT NULL AUTO_INCREMENT,
  `EngineerName` longtext,
  `EngineerContact` longtext,
  `HireDate` datetime(6) NOT NULL,
  PRIMARY KEY (`EngineerId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `LicenseEngineer`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `LicenseEngineer` (
  `LicenseEngineerId` int(11) NOT NULL AUTO_INCREMENT,
  `LicenseId` int(11) NOT NULL,
  `EngineerId` int(11) NOT NULL,
  PRIMARY KEY (`LicenseEngineerId`),
  KEY `IX_LicenseEngineer_EngineerId` (`EngineerId`),
  KEY `IX_LicenseEngineer_LicenseId` (`LicenseId`),
  CONSTRAINT `FK_LicenseEngineer_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_LicenseEngineer_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Licenses`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Licenses` (
  `LicenseId` int(11) NOT NULL AUTO_INCREMENT,
  `LicenseType` longtext,
  `IssueDate` datetime(6) NOT NULL,
  PRIMARY KEY (`LicenseId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `MachineLicense`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `MachineLicense` (
  `MachineLicenseId` int(11) NOT NULL AUTO_INCREMENT,
  `MachineId` int(11) NOT NULL,
  `LicenseId` int(11) NOT NULL,
  PRIMARY KEY (`MachineLicenseId`),
  KEY `IX_MachineLicense_LicenseId` (`LicenseId`),
  KEY `IX_MachineLicense_MachineId` (`MachineId`),
  CONSTRAINT `FK_MachineLicense_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE,
  CONSTRAINT `FK_MachineLicense_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Machines`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Machines` (
  `MachineId` int(11) NOT NULL AUTO_INCREMENT,
  `MachineName` longtext,
  `SerialNumber` longtext,
  `InstallDate` datetime(6) NOT NULL,
  PRIMARY KEY (`MachineId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


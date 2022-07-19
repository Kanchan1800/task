-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema new_database
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema new_database
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `new_database` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema walkinportal_new
-- -----------------------------------------------------
USE `new_database` ;

-- -----------------------------------------------------
-- Table `new_database`.`Walkin`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Walkin` (
  `WalkinId` INT NOT NULL,
  `Title` VARCHAR(45) NULL,
  `Duration` VARCHAR(45) NULL,
  `Roles` VARCHAR(45) NULL,
  `Location` VARCHAR(45) NULL,
  `GeneralInstructions` VARCHAR(45) NULL,
  `ExamInstructions` VARCHAR(45) NULL,
  `SystemRequirements` VARCHAR(45) NULL,
  `ExpiresIn` VARCHAR(45) NULL,
  `InternshipDetaisl` VARCHAR(45) NULL,
  PRIMARY KEY (`WalkinId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Timeslots`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Timeslots` (
  `TimeslotsId` INT NOT NULL,
  `SlotDetails` VARCHAR(45) NULL,
  `Walkin_Id` INT NOT NULL,
  PRIMARY KEY (`TimeslotsId`, `Walkin_Id`),
  INDEX `fk_timeslots_walkin_1_idx` (`Walkin_Id` ASC) VISIBLE,
  CONSTRAINT `fk_timeslots_walkin_1`
    FOREIGN KEY (`Walkin_Id`)
    REFERENCES `new_database`.`Walkin` (`WalkinId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`RoleDescription`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`RoleDescription` (
  `RoleDescriptionId` INT NOT NULL AUTO_INCREMENT,
  `RoleTitle` VARCHAR(45) NULL,
  `Package` INT NULL,
  PRIMARY KEY (`RoleDescriptionId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`ProfessionalQualification`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`ProfessionalQualification` (
  `ProfessionalQualificationId` INT NOT NULL,
  `Type` ENUM('fresher', 'experienced') NULL,
  `ExperienceYears` VARCHAR(45) NULL,
  `Current_ctc` VARCHAR(45) NULL,
  `Expected_ctc` VARCHAR(45) NULL,
  `Expertise` JSON NULL,
  `FamiliarTech` JSON NULL,
  `OnNoticePeriod` ENUM('yes', 'no') NULL,
  `NoticePeriodEnds` VARCHAR(45) NULL,
  `NoticeDuration` VARCHAR(45) NULL,
  `AppliedBefore` ENUM('yes', 'no') NULL,
  `RoleBefore` VARCHAR(45) NULL,
  PRIMARY KEY (`ProfessionalQualificationId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Users` (
  `UsersId` INT NOT NULL,
  `Firstname` VARCHAR(45) NULL,
  `Lastname` VARCHAR(45) NULL,
  `Email_id` VARCHAR(45) NULL,
  `Password` VARCHAR(45) NULL,
  `PhoneNo` BIGINT(15) NULL,
  `Status` VARCHAR(45) NULL,
  `PortfolioUrl` VARCHAR(45) NULL,
  `PreferredRoles` JSON NULL,
  `ProfessionalQualification_Id` INT NOT NULL,
  PRIMARY KEY (`UsersId`, `ProfessionalQualification_Id`),
  INDEX `fk_users_prof_qualification1_idx` (`ProfessionalQualification_Id` ASC) VISIBLE,
  CONSTRAINT `fk_users_prof_qualification1`
    FOREIGN KEY (`ProfessionalQualification_Id`)
    REFERENCES `new_database`.`ProfessionalQualification` (`ProfessionalQualificationId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`EducationalQualifications`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`EducationalQualifications` (
  `EducationalQualificationsId` INT NOT NULL,
  `Percentage` INT NULL,
  `College` VARCHAR(45) NULL,
  `Qualification` VARCHAR(45) NULL,
  `Stream` VARCHAR(45) NULL,
  `PassingYear` VARCHAR(45) NULL,
  `CollegeLocation` VARCHAR(45) NULL,
  `Users_Id` INT NOT NULL,
  PRIMARY KEY (`EducationalQualificationsId`, `Users_Id`),
  INDEX `fk_Edu_Qualifications_users2_idx` (`Users_Id` ASC) VISIBLE,
  CONSTRAINT `fk_Edu_Qualifications_users2`
    FOREIGN KEY (`Users_Id`)
    REFERENCES `new_database`.`Users` (`UsersId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`FamiliarTech`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`FamiliarTech` (
  `FamiliarTechId` INT NOT NULL,
  `TechName` JSON NULL,
  PRIMARY KEY (`FamiliarTechId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`PrefferedRoles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`PrefferedRoles` (
  `PrefferedRolesId` INT NOT NULL AUTO_INCREMENT,
  `RoleName` VARCHAR(45) NULL,
  PRIMARY KEY (`PrefferedRolesId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Application`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Application` (
  `ApplicationId` INT NOT NULL,
  `Preference` JSON NULL,
  `Resume` VARCHAR(45) NULL,
  `Walkin_Id` INT NOT NULL,
  `Users_Id` INT NOT NULL,
  `Timeslots_Id` INT NOT NULL,
  PRIMARY KEY (`ApplicationId`, `Walkin_Id`, `Users_Id`, `Timeslots_Id`),
  INDEX `fk_application_walkin_1_idx` (`Walkin_Id` ASC) VISIBLE,
  INDEX `fk_application_users2_idx` (`Users_Id` ASC) VISIBLE,
  INDEX `fk_application_timeslots1_idx` (`Timeslots_Id` ASC) VISIBLE,
  CONSTRAINT `fk_application_walkin_1`
    FOREIGN KEY (`Walkin_Id`)
    REFERENCES `new_database`.`Walkin` (`WalkinId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_application_users2`
    FOREIGN KEY (`Users_Id`)
    REFERENCES `new_database`.`Users` (`UsersId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_application_timeslots1`
    FOREIGN KEY (`Timeslots_Id`)
    REFERENCES `new_database`.`Timeslots` (`TimeslotsId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Roles` (
  `RolesId` INT NOT NULL,
  `Description` VARCHAR(45) NULL,
  `Requirements` VARCHAR(45) NULL,
  `ProcessDescription` VARCHAR(45) NULL,
  `RoleDescription_Id` INT NOT NULL,
  `Walkin_Id` INT NOT NULL,
  PRIMARY KEY (`RolesId`, `RoleDescription_Id`, `Walkin_Id`),
  INDEX `fk_roles_role_description1_idx` (`RoleDescription_Id` ASC) VISIBLE,
  INDEX `fk_roles_walkin_1_idx` (`Walkin_Id` ASC) VISIBLE,
  CONSTRAINT `fk_roles_role_description1`
    FOREIGN KEY (`RoleDescription_Id`)
    REFERENCES `new_database`.`RoleDescription` (`RoleDescriptionId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_roles_walkin_1`
    FOREIGN KEY (`Walkin_Id`)
    REFERENCES `new_database`.`Walkin` (`WalkinId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Users_has_PrefferedRoles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Users_has_PrefferedRoles` (
  `Users_Id` INT NOT NULL,
  `PrefferedRoles_Id` INT NOT NULL,
  PRIMARY KEY (`Users_Id`, `PrefferedRoles_Id`),
  INDEX `fk_users_has_preffered_roles_preffered_roles1_idx` (`PrefferedRoles_Id` ASC) VISIBLE,
  INDEX `fk_users_has_preffered_roles_users1_idx` (`Users_Id` ASC) VISIBLE,
  CONSTRAINT `fk_users_has_preffered_roles_users1`
    FOREIGN KEY (`Users_Id`)
    REFERENCES `new_database`.`Users` (`UsersId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_preffered_roles_preffered_roles1`
    FOREIGN KEY (`PrefferedRoles_Id`)
    REFERENCES `new_database`.`PrefferedRoles` (`PrefferedRolesId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`ProfessionalQualificationi_has_familiar_tech`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`ProfessionalQualificationi_has_familiar_tech` (
  `ProfessionalQualification_Id` INT NOT NULL,
  `FamiliarTech_Id` INT NOT NULL,
  PRIMARY KEY (`ProfessionalQualification_Id`, `FamiliarTech_Id`),
  INDEX `fk_prof_qualification_has_familiar_tech_familiar_tech1_idx` (`FamiliarTech_Id` ASC) VISIBLE,
  INDEX `fk_prof_qualification_has_familiar_tech_prof_qualification1_idx` (`ProfessionalQualification_Id` ASC) VISIBLE,
  CONSTRAINT `fk_prof_qualification_has_familiar_tech_prof_qualification1`
    FOREIGN KEY (`ProfessionalQualification_Id`)
    REFERENCES `new_database`.`ProfessionalQualification` (`ProfessionalQualificationId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_prof_qualification_has_familiar_tech_familiar_tech1`
    FOREIGN KEY (`FamiliarTech_Id`)
    REFERENCES `new_database`.`FamiliarTech` (`FamiliarTechId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `new_database`.`Application_maps_Roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `new_database`.`Application_maps_Roles` (
  `Application_Id` INT NOT NULL,
  `Roles_Id` INT NOT NULL,
  PRIMARY KEY (`Application_Id`, `Roles_Id`),
  INDEX `fk_application_has_roles_roles1_idx` (`Roles_Id` ASC) VISIBLE,
  INDEX `fk_application_has_roles_application1_idx` (`Application_Id` ASC) VISIBLE,
  CONSTRAINT `fk_application_has_roles_application1`
    FOREIGN KEY (`Application_Id`)
    REFERENCES `new_database`.`Application` (`ApplicationId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_application_has_roles_roles1`
    FOREIGN KEY (`Roles_Id`)
    REFERENCES `new_database`.`Roles` (`RolesId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

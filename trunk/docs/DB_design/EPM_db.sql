SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `mydb`;

-- -----------------------------------------------------
-- Table `mydb`.`project`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`project` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(255) NULL ,
  `desc` TEXT NULL ,
  `start` DATETIME NULL ,
  `end` DATETIME NULL ,
  `status` TINYINT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`user` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(128) NULL ,
  `email` VARCHAR(128) NULL ,
  `phone` INT NULL ,
  `pass` VARCHAR(45) NULL ,
  `company` VARCHAR(45) NULL ,
  `gender` INT NULL ,
  `address` VARCHAR(512) NULL ,
  `country` VARCHAR(45) NULL ,
  `admin` TINYINT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`project_assigned`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`project_assigned` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `project_id` INT NULL ,
  `user_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_project_assigned_project (`project_id` ASC) ,
  INDEX fk_project_assigned_user (`user_id` ASC) ,
  CONSTRAINT `fk_project_assigned_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `mydb`.`project` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_project_assigned_user`
    FOREIGN KEY (`user_id` )
    REFERENCES `mydb`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`action`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`action` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`module`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`module` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`module_action`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`module_action` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `module_id` INT NULL ,
  `action_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_module_action_action (`action_id` ASC) ,
  INDEX fk_module_action_module (`module_id` ASC) ,
  CONSTRAINT `fk_module_action_action`
    FOREIGN KEY (`action_id` )
    REFERENCES `mydb`.`action` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_module_action_module`
    FOREIGN KEY (`module_id` )
    REFERENCES `mydb`.`module` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`role`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`role` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `project_id` INT NULL ,
  `name` VARCHAR(45) NULL ,
  `admin` TINYINT NULL COMMENT 'có phải là admin của poject này ko' ,
  `module_action_id` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_role_project (`project_id` ASC) ,
  INDEX fk_role_module_action (`module_action_id` ASC) ,
  CONSTRAINT `fk_role_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `mydb`.`project` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_role_module_action`
    FOREIGN KEY (`module_action_id` )
    REFERENCES `mydb`.`module_action` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`role_assigned`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`role_assigned` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `user_id` INT NULL ,
  `role_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_role_assigned_user (`user_id` ASC) ,
  INDEX fk_role_assigned_role (`role_id` ASC) ,
  CONSTRAINT `fk_role_assigned_user`
    FOREIGN KEY (`user_id` )
    REFERENCES `mydb`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_role_assigned_role`
    FOREIGN KEY (`role_id` )
    REFERENCES `mydb`.`role` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`milestones`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`milestones` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `project_id` INT NULL ,
  `name` VARCHAR(45) NULL ,
  `desc` TEXT NULL ,
  `start` DATETIME NULL ,
  `end` DATETIME NULL ,
  `status` TINYINT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_milestones_project (`project_id` ASC) ,
  CONSTRAINT `fk_milestones_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `mydb`.`project` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`milestones_assigned`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`milestones_assigned` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `milestones_id` INT NULL ,
  `user_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_milestones_assigned_milestones (`milestones_id` ASC) ,
  INDEX fk_milestones_assigned_user (`user_id` ASC) ,
  CONSTRAINT `fk_milestones_assigned_milestones`
    FOREIGN KEY (`milestones_id` )
    REFERENCES `mydb`.`milestones` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_milestones_assigned_user`
    FOREIGN KEY (`user_id` )
    REFERENCES `mydb`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tasklist`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`tasklist` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `project_id` INT NULL ,
  `milestones_id` INT NULL ,
  `name` VARCHAR(255) NULL ,
  `desc` TEXT NULL ,
  `start` DATETIME NULL ,
  `end` DATETIME NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_tasklist_project (`project_id` ASC) ,
  INDEX fk_tasklist_milestones (`milestones_id` ASC) ,
  CONSTRAINT `fk_tasklist_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `mydb`.`project` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tasklist_milestones`
    FOREIGN KEY (`milestones_id` )
    REFERENCES `mydb`.`milestones` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tasks`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`tasks` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `tasklist_id` INT NULL ,
  `start` DATETIME NULL ,
  `end` DATETIME NULL ,
  `title` VARCHAR(128) NULL ,
  `desc` TEXT NULL ,
  `status` TINYINT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_tasks_tasklist (`tasklist_id` ASC) ,
  CONSTRAINT `fk_tasks_tasklist`
    FOREIGN KEY (`tasklist_id` )
    REFERENCES `mydb`.`tasklist` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tasks_assigned`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`tasks_assigned` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `user_id` INT NULL ,
  `tasks_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_tasks_assigned_user (`user_id` ASC) ,
  INDEX fk_tasks_assigned_tasks (`tasks_id` ASC) ,
  CONSTRAINT `fk_tasks_assigned_user`
    FOREIGN KEY (`user_id` )
    REFERENCES `mydb`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tasks_assigned_tasks`
    FOREIGN KEY (`tasks_id` )
    REFERENCES `mydb`.`tasks` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`time_tracker`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`time_tracker` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `user_id` INT NULL ,
  `project_id` INT NULL ,
  `tasks_id` INT NULL ,
  `comment` TEXT NULL ,
  `start` DATETIME NULL ,
  `end` DATETIME NULL ,
  `hours` FLOAT NULL ,
  `status` TINYINT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX fk_time_tracker_user (`user_id` ASC) ,
  INDEX fk_time_tracker_project (`project_id` ASC) ,
  INDEX fk_time_tracker_tasks (`tasks_id` ASC) ,
  CONSTRAINT `fk_time_tracker_user`
    FOREIGN KEY (`user_id` )
    REFERENCES `mydb`.`user` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_time_tracker_project`
    FOREIGN KEY (`project_id` )
    REFERENCES `mydb`.`project` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_time_tracker_tasks`
    FOREIGN KEY (`tasks_id` )
    REFERENCES `mydb`.`tasks` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

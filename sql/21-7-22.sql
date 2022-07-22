use walkinportals_db;
call show_tables("application");

call AddProfessionalQualifications('experienced','3','5lpa','10lpa', json_array(json_object('expertise', 'java , php')), json_array(json_object('familiar_tech', 'angular nodejs')),'no',null,null,'no',null);
use walkinportals_db;
call RegisterUser('kanchan','choudhary','kanuchoudhary2000@gmail.com','12345' ,'1234567','applied','-', json_array(json_object('PrefferedRoles', 'java , php')),
'experienced','3','5lpa','10lpa', json_array(json_object('expertise', 'java , php')), json_array(json_object('familiar_tech', 'angular nodejs')),'no',null,null,'no',null,
90,'rgit','be','cs','2022','andheri');
use walkinportals_db;
call RegisterUser('vaishnavi','kulkarni','vaishnavi2000@gmail.com','123456' ,'12345678','not applied','-', json_array(json_object('PrefferedRoles', 'dev , qa')),
'experienced','5','10lpa','15lpa', json_array(json_object('expertise', 'java , php')), json_array(json_object('familiar_tech', 'angular nodejs')),'no',null,null,'no',null,
90,'ruia','be','cs','2022','dadar');
select * from users;
select * from professionalqualification;
select * from educationalqualifications;
select * from walkin;
/*
create table temp (p_id int ,e_id int);
insert into temp values(1,1);
insert into temp values(1,2);
INSERT INTO professionalqualification_has_expertisein(ProfessionalQualification_Id,ExpertiseIn_Id)
SELECT professionalqualification.ProfessionalQualificationId,expertisein.ExpertiseInId
FROM temp
JOIN professionalqualification ON temp.p_id = professionalqualification.value
JOIN expertisein ON temp.e_id = expertisein.value;
drop table temp;*/
select * from users;
ALTER TABLE users DROP COLUMN PreferredRoles;
ALTER TABLE users CHANGE UsersId Id int primary key  ;
ALTER TABLE users RENAME COLUMN UsersId TO Id;
INSERT INTO `walkinportals_db`.`walkin`
(`Title`,`Duration`,`Roles`,`Location`,`GeneralInstructions`,`ExamInstructions`,
`SystemRequirements`,`ExpiresIn`,`InternshipDetaisl`)
VALUES
("Walkin for multiple roles","1-Jul-2022 to 14-Jul-2022","['dev','qa']","Mumbai","blah blah blah g ..","exam 1",
"blah blah blahs ..","blah blah blahs ..","blah blah blahs ..");
INSERT INTO `walkinportals_db`.`walkin`
(`Title`,`Duration`,`Roles`,`Location`,`GeneralInstructions`,`ExamInstructions`,
`SystemRequirements`,`ExpiresIn`,`InternshipDetaisl`)
VALUES
("Walkin for designer roles","10-Jul-2022 to 24-Jul-2022","['designer','qa']","Mumbai","blah blah blah g ..","exam 1",
"blah blah blahs ..","blah blah blahs ..","blah blah blahs ..");
ALTER TABLE walkin RENAME COLUMN WalkinId TO Id;
ALTER TABLE application DROP COLUMN Preference;
ALTER TABLE application RENAME COLUMN ApplicationId TO Id;
ALTER TABLE timeslots RENAME COLUMN TimeslotsId TO Id;
ALTER TABLE roles RENAME COLUMN RolesId TO Id;
ALTER TABLE users RENAME COLUMN type TO Id;
ALTER TABLE professionalqualification CHANGE Type IsFresher bool  ;
ALTER TABLE professionalqualification RENAME COLUMN ProfessionalQualificationId TO Id;
ALTER TABLE professionalqualification CHANGE GivenZeusTest GivenZeusTest bool  ;
ALTER TABLE professionalqualification CHANGE OnNoticePeriod OnNoticePeriod boolean  ;
ALTER TABLE professionalqualification CHANGE AppliedBefore AppliedBefore bool  ;
insert into timeslots value(1,'11 to 2',1);
insert into timeslots value(2,'3 to 6',1);
insert into timeslots value(3,'9 to 12',2);


ALTER TABLE application RENAME COLUMN WalkinId TO Walkin_Id;
ALTER TABLE application RENAME COLUMN UsersId TO Users_Id;
ALTER TABLE application RENAME COLUMN TimeslotsId TO Timeslots_Id;
ALTER TABLE timeslots RENAME COLUMN WalkinId TO Walkin_Id;
ALTER TABLE roles RENAME COLUMN WalkinId TO Walkin_Id;






















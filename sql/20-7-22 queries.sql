use walkinportals_db;
INSERT INTO `walkinportals_db`.`expertisein`(`TechName`)VALUES('Javascript');
INSERT INTO `walkinportals_db`.`expertisein`(`TechName`)VALUES('Angular JS');
INSERT INTO `walkinportals_db`.`expertisein`(`TechName`)VALUES('React JS');
INSERT INTO `walkinportals_db`.`expertisein`(`TechName`)VALUES('Node JS');
INSERT INTO `walkinportals_db`.`expertisein`(`TechName`)VALUES('Others');

INSERT INTO `walkinportals_db`.`familiartech`(`TechName`)VALUES('Javascript');
INSERT INTO `walkinportals_db`.`familiartech`(`TechName`)VALUES('Angular JS');
INSERT INTO `walkinportals_db`.`familiartech`(`TechName`)VALUES('React JS');
INSERT INTO `walkinportals_db`.`familiartech`(`TechName`)VALUES('Node JS');
INSERT INTO `walkinportals_db`.`familiartech`(`TechName`)VALUES('Others');

INSERT INTO `walkinportals_db`.`prefferedroles`(`RoleName`)VALUES('Instructional Designer');
INSERT INTO `walkinportals_db`.`prefferedroles`(`RoleName`)VALUES('Software Engineer');
INSERT INTO `walkinportals_db`.`prefferedroles`(`RoleName`)VALUES('Software Quality Engineer');

select * from expertisein;
select * from familiartech;
select * from prefferedroles;





call RegisterUser('new22kanchan','new22choudhary','kanuchoudhary3000@gmail.com','12345' ,'1234567','applied','-',
'experienced','3','5lpa','10lpa','no',null,null,'no',null,'no',
90,'rgit','be','cs','2022','andheri', '[1,2]');
select*from professionalqualification_has_expertisein;
select * from professionalqualification;
call RegisterUser('vaishnavi','kulkarni','vaishnavi2000@gmail.com','123456' ,'12345678','not applied','-',
'experienced','5','10lpa','15lpa','no',null,null,'no',null,
90,'ruia','be','cs','2022','dadar');
select * from walkinportals_db.users;
select * from professionalqualification;
select * from educationalqualifications;
create table temp (id int);
CALL `walkinportals_db`.`GetUser`(24);
select * from temp;
INSERT INTO `walkinportals_db`.`temp`(`id`)VALUES(1);
select id from `walkinportals_db`.`temp`;
drop table temp;
CALL `walkinportals_db`.`GetAllApplications`();

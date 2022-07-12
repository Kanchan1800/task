INSERT INTO `new_database`.`users`
(`id`,`firstname`,`lastname`,`email_id`,`password`,`phone_no`,`status`,`portfolio_url`,`prof_qualification_id`)
VALUES
(11,'kanchan','choudhary','kanuchoudhary2000@gmail.com','12345' ,'1234567','applied','-',1);

INSERT INTO `new_database`.`users`
(`id`,`firstname`,`lastname`,`email_id`,`password`,`phone_no`,`status`,`portfolio_url`,`prof_qualification_id`)
VALUES
(22 ,'vaishnavi','kulkarni','vaish2000@gmail.com','12345' ,'1234567','not applied','-',2);

INSERT INTO `new_database`.`prof_qualification`
(`id`,`type`,`applied_before`)
VALUES(1,'fresher','no');

INSERT INTO `new_database`.`prof_qualification`
(`id`,`type`,`exp_years`,`current_ctc`,`expected_ctc`,`expertise`,`familiar_tech`,`on_notice_period`,`applied_before`)
VALUES
(2,'experienced','3','5lpa','10lpa', json_array(json_object('expertise', 'java , php')), json_array(json_object('familiar_tech', 'angular nodejs')),'no','no');

select * from prof_qualification;

select * from users left join prof_qualification on users.prof_qualification_id=prof_qualification.id;

delete from users where id=1;
select * from users;
select * from users left join prof_qualification on users.prof_qualification_id=prof_qualification.id;

INSERT INTO `new_database`.`walkin`
(`id`,`title`,`duration`,`roles`,`location`,`general_instruc`,`exam_instruc`,`system_req`,`expires_in`,`internship_details`)
VALUES
(1,'walkin job roles for multiple jobs','30-jun-2022 - 5-jul-2022',json_array(json_object('roles', 'DEV,QA,DESIGN')),'MUMBAI',
'general_instructionss','exam instructions','system requirements','4 days','internship available');
select id from walkin where title='walkin job roles for multiple';
delete from timeslots where id=1;
insert into timeslots value(1,'11 to 2',1);
insert into timeslots value(2,'3 to 5',1);
insert into role_description values(1,'DEV',60000);
insert into role_description values(2,'QA',60000);
insert into role_description values(3,'DESIGN',60000);
aLTER TABLE roles
ADD CONSTRAINT MyUniqueConstraint UNIQUE(id, walkin_id,role_description_id);
INSERT INTO roles values(1,'description','requirements','process',1,1);
INSERT INTO roles values(2,'description','requirements','process',2,1);
INSERT INTO roles values(3,'description','requirements','process',3,1);
update roles set description='description2',requirements='requirements2' where id=2;
update roles set description='description3',requirements='requirements3' where id=3;
select id,title,duration,roles,location,expires_in,internship_details from walkin;

/*---on clicking view more pass walkin id further ---
---login----*/

select id from users where users.email_id='username' and users.password='password';

/*if id is not empty proceed further with walkin_id and users_id*/
/*details of all walkin their timeslot,roles details*/
select  * from
(select * from 
(select walkin_id as wi,title,duration,roles,location,expires_in,internship_details,slot_details from walkin w join timeslots t on w.id=t.walkin_id)as n
left join 
(select role_title,description ,package,walkin_id from roles join role_description on roles.role_description_id=role_description.id)as r
on n.wi=r.walkin_id) as de group by role_title; 

/*display walkin details,timeslots,roles present in the given walkin */
select * from walkin where id=1;
select * from timeslots where walkin_id=1;
select * from roles left join role_description rd on role_description_id=rd.id where walkin_id=1;
    
 /* ---to get which id of slot user has selected in the given walkin---*/ 
select id from timeslots where timeslots.slot_details='3 to 5' and timeslots.walkin_id=1;
/*GET ID OF THE ROLE which the user has selected in the given walkin*/
select id from roles where role_description_id =(select id from role_description rd where rd.role_title='DEV' AND walkin_id=1);
/*INSERT INTO APPLICATION */
insert into application values(1,json_array(json_object('PREFERECE', 'DEV,QA')),'RESUME.pdf',1,1,11,2)  ;

/*GET ALL APPLICATIONS DATA*/
select aid,firstname,lastname,email_id,phone_no,status,prof_qualification_id,wid,title,slot_details,rid,role_name,package from (select aid,firstname,lastname,email_id,phone_no,status,prof_qualification_id,rid,wid,role_name,package,slot_details from(select aid,firstname,lastname,email_id,phone_no,status,prof_qualification_id,rid,wid,slot_details from  (select a.id as aid,a.preference,a.resume,a.users_id,a.walkin_id as wid,a.roles_id as rid,t.slot_details from application a left join timeslots t on a.timeslots_id=t.id) as app
left join users on app.users_id=users.id )as userapp
left join (select roles.id,rd.role_title as role_name,rd.package from roles left join role_description rd on roles.role_description_id=rd.id) as rdd on rdd.id=userapp.rid )as newdata left join walkin on newdata.wid=walkin.id;
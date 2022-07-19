const Joi=require('joi');
const express=require('express');
const app=express();
 const port =3000;

 app.use(express.json()); //middleware
 app.listen(port,
    ()=>console.log(`api is listening on ${port}`));

const courses=[
    { id:1,name:"course 1"},
    { id:2,name:"course 2"},
    { id:3,name:"course 3"},
    { id:4,name:"course 4"},
]

const walkins=[ { Id : 1, Title : "Walkin for multiple roles", Duration : "1-Jul-2022 to 14-Jul-2022",Roles:['DEV','QA','DESIGNER'],Location:"Mumbai",General_instruc:"blah blah blah g ..",Exam_instruc:"exams info",System_req:"blah blah blahs ..",ExpiresIn:"5",InternshipDetails:null },
{ Id : 2, Title : "Walkin for designer roles", Duration : "10-Jul-2022 to 24-Jul-2022",Roles:['DESIGNER'],Location:"Mumbai",General_instruc:"blah blah blah g2 ..",Exam_instruc:"exams info",System_req:"blah blah blahs2 ..",ExpiresIn:"10",InternshipDetails:"Opportunity for MCA students" },

]
app.get('/',(req,res)=>{
    res.send('hello codiess');
});
app.get('/courses',(req,res)=>{
    res.send(courses);
});
app.get('/courses/:id',(req,res)=>{
    const course=courses.find(c=>c.id===parseInt(req.params.id))
    if(!course) return res.status(404).send('id not found')
    res.send(course)
});
app.post('/courses',(req,res)=>
{   
    const schema={
        name:Joi.string().min(3).required()
    }
    const result=Joi.validate(req.body,schema);
    console.log(result);
    //if(!req.body.name || req.body.name.length<3)
    if(result.error)
    {
        res.status(400).send(result.error.details[0].message)
        res.send('name is required');
        return;
    }
    const course={
        id: courses.length + 1,
        name: req.body.name
    }
    courses.push(course);
    res.send(course);
});

app.put('/courses/:id',(req,res)=>
{
    let course=courses.find(c=>c.id===parseInt(req.params.id))
    if(!course) 
    {
        res.status(404).send('id not found')
    return;
    }

    const schema={
        name:Joi.string().min(3).required()
    }
    const result=Joi.validate(req.body,schema);
    if(result.error)
    {
        res.status(400).send(result.error.details[0].message)
        //res.send('name is required');
        return;
    }
    course.name=req.body.name;
    res.send(course);



});

app.delete('/courses/:id',(req,res)=>{
    let course=courses.find(c=>c.id===parseInt(req.params.id))
    if(!course) {
        res.status(404).send('id not found');
        return;
    }
    const index=courses.indexOf(course);
    courses.splice(index,1);
    res.send(course)
})

app.get('/walkin',(req,res)=>{
    // const res = {
    //     statusCode: 200,
    //     headers: {
    //         "Access-Control-Allow-Headers" : "Content-Type",
    //         "Access-Control-Allow-Origin": "http://localhost:4200",
    //         "Access-Control-Allow-Methods": "OPTIONS,POST,GET"
    //     },
    //     body: JSON.stringify(walkins),
    // };
    res.status(200).header({ "Access-Control-Allow-Headers" : "Content-Type",
    "Access-Control-Allow-Origin": "http://localhost:4200",
    "Access-Control-Allow-Methods": "OPTIONS,POST,GET"}).send(walkins);
    //res.send(walkins);
});
app.get('/walkin/:id',(req,res)=>{
    const walkin=walkins.find(c=>c.Id===parseInt(req.params.id))
    console.log(walkin);
    if(!walkin) return res.status(404).send('id not found')
    res.status(200).header({ "Access-Control-Allow-Headers" : "Content-Type",
    "Access-Control-Allow-Origin": "http://localhost:4200",
    "Access-Control-Allow-Methods": "OPTIONS,POST,GET"}).send(walkin);
    //res.send(walkin)
});


app.post('/walkin',(req,res)=>
{   
    const schema={
        Title : Joi.string().required(),
         Duration : Joi.string().required(),
         Roles: Joi.required(),
         Location:Joi.string().required(),
         General_instruc:Joi.string().required(),
         Exam_instruc:Joi.string().required(),
         System_req:Joi.string().required(),
         ExpiresIn:Joi.string(),
         InternshipDetails:Joi.string()
    }
    const result=Joi.validate(req.body,schema);
    console.log(result);
    //if(!req.body.name || req.body.name.length<3)
    if(result.error)
    {
        res.status(400).send(result.error.details[0].message)
        res.send('all fields is required');
        return;
    }
    const walkin={
        id: walkins.length + 1,
        Title : req.body.Title,
         Duration : req.body.Duration,
         Roles: req.body.Roles,
         Location:req.body.Location,
         General_instruc:req.body.General_instruc,
         Exam_instruc:req.body.Exam_instruc,
         System_req:req.body.System_req,
         ExpiresIn:req.body.ExpiresIn,
         InternshipDetails:req.body.InternshipDetails
    }
    walkins.push(walkin);
    res.status(200).header({ "Access-Control-Allow-Headers" : "Content-Type",
    "Access-Control-Allow-Origin": "http://localhost:4200",
    "Access-Control-Allow-Methods": "OPTIONS,POST,GET"}).send(walkin);
    //res.send(course);
});
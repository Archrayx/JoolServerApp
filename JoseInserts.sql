
/*Product*/

/*Feedback Insert */
Insert [dbo].tblFeedBack([Feeback_ID], [User_ID], [Product_ID], [Feedback_Time], [Feedback_Score], [Feedback_Content] 
values('fbk098432', [USER_ID], 'FAN098234', '14:12', '4', 'Great quality and very pretty. Only downfall is the lighting. It doesn’t use a standard light bulb. This is my fault for not reading details.')

Insert [dbo].tblFeedBack([Feeback_ID], [User_ID], [Product_ID], [Feedback_Time], [Feedback_Score], [Feedback_Content] 
values('fbk839290', [User_ID], 'LAM098234', '8:33', '3', 'Honestly I was pretty shocked when I received the lamp, super easy to assemble and use, all you need to do is screw on the lightbulb and tap the base, very relaxing and fun.')

Insert [dbo].tblFeedBack([Feeback_ID], [User_ID], [Product_ID], [Feedback_Time], [Feedback_Score], [Feedback_Content] 
values('fbk982893', [User_ID], 'HUM098234', '9:34', '5', 'Better then expected. Fast delivery and great little humidifier! Quiet and powerful')

/* Category Insert */ 
Insert [dbo].tblCategory([Category_ID], [Category_Name]) Values('4356', 'Decor')
Insert [dbo].tblCategory([Category_ID], [Category_Name]) Values('3241', 'Lighting')
Insert [dbo].tblCategory([Category_ID], [Category_Name]) Values('9870', 'Cooling')

/*Project */ 
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values([Project_ID], 'FAN098234', 33)
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values([Project_ID], 'LAM098234', 27)
Insert [dbo].tblProjToProd([Project_ID], [Product_ID], [Quantity]) values([Project_ID], 'HUM098234', 303)

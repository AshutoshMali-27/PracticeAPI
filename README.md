
DAL -Irepo
Irepository -Model
Servises -IRepo ,DAL ,Model
Project -DAL ,Repo ,Model ,Servicse


DAL -
microsoftdataSqlclient 5.2.2
microsoftentityframewrokcoresqlserver 8.0.0

model
microsoftEntityFremeworkcore 8.0.0
microsoftEntityFremeworkcoretools 8.0.0

Irepo
microsoftdataSqlclient 5.2.2

Servises
microsoftdataSqlclient 5.2.2
microsoftEntityFremeworkcore 8.0.10
microsoftEntityFremeworkcore design 8.0.10
microsoftEntityFremeworkcore SQlServer 8.0.10
microsoftEntityFremeworkcore Tools8.0.10
microsoftExtension Configuration 8.0.10


Project
Entity FrameworkCoreDesign 8.0.0
microsoftEntityFremeworkcore SQlServer 8.0.10
MicrosoftExtension.configuration.FileExtension 9.0.0


add connectionstring in appsetting.json


Scaffold-DbContext "Server=192.168.0.162;Database=15-Finance-DMA-dev-Testing;User ID=dbo_15-Finance-DMA_QA;Password=zMbVy8519vb9;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "C:\Practice\PracticeApplication\Model" -Context YourDbContext -Force


 Scaffold-DbContext "Server=LAPTOP-92R3ST6F\SQLEXPRESS;Database=practiceproject;Integrated Security=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "C:\Users\ashutosh\Desktop\Dot netCore APP\PracticeSolution\PRacticesetMVC\Models" -Context DemoDbContext -Force


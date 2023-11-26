    How To Run Project?
After clonning the project locate CompanyMng.sln file and open it. Before running the application configure your sql server name

  ![sql](https://github.com/DenizS4/CompanyMng/assets/121265021/178f3155-a512-45b3-b11c-22c2ad3fe489)

and add it to app.setting.json inside CompanyMngConnectionString to Data Source.

![appsettings](https://github.com/DenizS4/CompanyMng/assets/121265021/8eeca554-c5ca-4821-83e4-4079216f18f6)

After adding your sql server name open up terminal execute following command

dotnet ef database update --project CompanyMng.Infrastructure --startup-project CompanyMng.API 

![dbupdate](https://github.com/DenizS4/CompanyMng/assets/121265021/6fd4d3c4-f99f-43a4-900c-c2bbd26e09ea)

after executing the command run the project as so

![iis](https://github.com/DenizS4/CompanyMng/assets/121265021/4e957a20-18b2-4082-aedb-72e9ca9116fe)

https://localhost:44372/swagger/index.html should launch if 44372 port is taken or unavailable you are going to need to configure base url manually.

![swagger](https://github.com/DenizS4/CompanyMng/assets/121265021/c077a63c-0c78-478c-8d0d-926b088711af)

Next step locate CompanyMng.UI either run code . from terminal or open from your ide manually

![ui](https://github.com/DenizS4/CompanyMng/assets/121265021/835220f3-5b8f-427f-a0a5-4124b9ef0a19)

After opening ui project if your swagger port was diffrent than 44372 as mentioned before locate src/app/shared/Api.ts

![baseurl](https://github.com/DenizS4/CompanyMng/assets/121265021/a9debce3-48ef-4f68-8712-d9858e06497c)

set base url same as yours here and continue
open up the terminal from ide and run npm install

![npminstall](https://github.com/DenizS4/CompanyMng/assets/121265021/5ae4560e-970f-4d1c-ae99-6da8c110f788)

then run ng serve -o this will fire up the project

![ngserve](https://github.com/DenizS4/CompanyMng/assets/121265021/f23c7d93-397c-4f0d-9991-7fd99d54bc1e)

You will get into the logging screen. If you followed the above steps 2 default users will be setup for you

![login](https://github.com/DenizS4/CompanyMng/assets/121265021/be4c38f8-6501-4f51-889b-a7df9c3615c7)

use "username = admin password = admin" for logging in as admin

use "username = user password = user" for logging in as user

as admin you are going to have access to users table unlike users. You can also use signup page for creating new account but new signed accounts signs as user so you need to use admin account at least once to promote yourself admin.



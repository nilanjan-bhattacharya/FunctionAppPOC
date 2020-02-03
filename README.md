# FunctionAppPOC
It is a sample Azure Function version 3
With CodeFirst EFCore 3.1

Need to run following commands on PackageManager
$env:SqlConnectionString= "Server=localhost;Database=HeroGames;Trusted_Connection=True" 
Add-Migration InitialCreate 
Update-Database


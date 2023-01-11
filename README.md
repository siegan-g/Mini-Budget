# Mini-Budget v.3.0a

 ~~Mini-Budget is a personal financing CLI application written in CSharp with .NET Framework 4.7.2 based around user input and providing simple deductions to a gross income.~~
 As of Version 3.0a Mini-Budget is a GUI focused personal financing application written in C# and WPF with .NET Framework 5.0. CLI functionality still exists and both GUI and CLI applications should be available in the future. 


## Changelog 
* Overhauled application to use the Window's Presentation Foundation (WPF) GUI framework.
* Completely rewritten previous classes, particularly subclasses to be more abstract. 
* Added a new class that holds CLI functionality, though is not called or utilised as of this version. 
* Several new dependencies are added to expand on WPF, particuarly in appearance and design. 
* Added a new feature to calculate monthly savings.
* Added further documentation -> a PDF detailing the program, new class diagram, expanded upon Readme.

 ## Features
 * Allows User input with convenient exception handling.
 * Provides calculation for essential general expenses.
 * Provides calculations and cost deductions for simple interest on home loan's and vehicle loan's. 
 * Provides a summary of monthly expenditures. As of this version only viewing the current month is supported. 
 * Stores user data into .txt files 


## Dependencies 
* .NET Framework 5.0
* Emoji.Wpf 0.3.3 - Allows the use of colour emojis in textbox's and textblocks
* MaterialDesignThemes 4.1.0 - Provides a Google Material Design style 
* ShowMeTheXAML.MSBuild 2.0.0 - A dependency for MaterialDesignThemes

## System Requirements
* 1 GHZ CPU minimum 
* 512MB RAM minimum 
* Windows 8.1 or greater

## Installation 
* Clone this repo ```git clone https://github.com/siegan-g/PROG_POE_Final.git``` or alternatively download the zipped folders through Github 
* Unzip the file and navigate to the main directory
* If your home is the console then run ```dotnet build``` followed by ```dotnet run``` to run the program
* Alternatively you may build and run through Visual Studio
 
## How it Works
### Class Domain Diagram of expenses in Program
```                                                                                                                                                        ┌────────────────────────────────┐
                                                                                                                                                        │    ExpenseInterface            │
                                                                                                                                                        ├────────────────────────────────┤
                                                                                                                                                        │                                │
                                                                                                                                                        │    +CalcExpense(double value)  │
                                                                                                                                                        │                                │
                                                                                                                                                        │    +GetExpense():double        │
                                                                                                                                                        │                                │
                                                                                                                                                        │                                │
                                                                                                                                                        └───────────────▲────────────────┘
                                                                                                                                                                        │
                                                                                                                                                                        │
                                                                                                                                                                        │
                                                                                                                                                        ┌───────────────┴────────────────────────┐
                                                                                                                                                        │    EveryExpense                        │
                                                                                                                                                        ├────────────────────────────────────────┤
                                                                                                                                                        │                                        │
                                                                                                                                                        │                                        │
                                                                                                                                                        │ ~CalcExpense(double value)             │
                                                                                                                                                        │                                        │
                                                                                                                                                        │ ~GetExpense():double                   │
                                                                                                                                                        │                                        │
                                                                                                                                                        │ ~ToString():string <<override>>        │
                                                                                                                                                        │                                        │
                                                                                                                                                        │ +LoanCalculator(double principalAmount,│
                                                                                                                                                        │  double deposit, double interest, int  │
                                                                                                                                                        │  period) : double                      │
                                                                                                                                                        └────────────────▲───────────────────────┘
                                                                                                                                                                         │
                                                                                                                          ┌──────────────────────────────────────────────┼───────────────────────────────────────┬────────────────────────────────────────────┬────────────────────────────────────────────┐
                                                                                                                          │                                              │                                       │                                            │                                            │
                                                                                                              ┌───────────┴──────────────────┐           ┌───────────────┴──────────────┐       ┌────────────────┴─────────────┐        ┌─────────────────────┴─────────────────┐     ┌────────────────────┴──────────────────┐
                                                                                                              │            Tax               │           │      GeneralExpenses         │       │     Rent                     │        │        HomeLoan                       │     │       Car                             │
                                                                                                              ├──────────────────────────────┤           ├──────────────────────────────┤       ├──────────────────────────────┤        ├───────────────────────────────────────┤     ├───────────────────────────────────────┤
                                                                                                              │                              │           │                              │       │                              │        │                                       │     │                                       │
                                                                                                              │                              │           │                              │       │                              │        │+CalcExpense(double value)             │     │+CalcExpense(double value)             │
                                                                                                              │ +CalcExpense(double value)   │           │ +CalcExpense(double value)   │       │ +CalcExpense(double value)   │        │                                       │     │                                       │
                                                                                                              │                              │           │                              │       │                              │        │+GetExpense():double                   │     │+GetExpense():double                   │
                                                                                                              │ +GetExpense():double         │           │ +GetExpense():double         │       │ +GetExpense():double         │        │                                       │     │                                       │
                                                                                                              │                              │           │                              │       │                              │        │+ToString():string <<override>>        │     │+ToString():string <<override>>        │
                                                                                                              │ +ToString():string <<override>>          │ +ToString():string <<override>>      │ +ToString():string <<override>>       │                                       │     │                                       │
                                                                                                              │                              │           │                              │       │                              │        │+LoanCalculator(double principalAmount,│     │+LoanCalculator(double principalAmount,│
                                                                                                              │                              │           │                              │       │                              │        │ double deposit, double interest, int  │     │ double deposit, double interest, int  │
                                                                                                              │                              │           │                              │       │                              │        │ period) : double                      │     │ period) : double                      │
                                                                                                              │                              │           │                              │       │                              │        │                                       │     │                                       │
                                                                                                              └─────────────────┬────────────┘           └───────────────┬──────────────┘       └──────────────┬───────────────┘        └─────────────────┬─────────────────────┘     └──────────────┬────────────────────────┘
                                                                                                                                │                                        │                                     │                                          │                                          │
                                                                                                                                │                                        │                                     │                                          │                                          │
                                                                                                                                │                                        │                                     │                                          │                                          │
                                                                                                                                │                                        │                                     │                                          │                                          │
                                                                                                                                │                                        │                                     │                                          │                                          │
                                                                                                                 ┌──────────────┴───────────────┐          ┌─────────────┴────────────────┐     ┌──────────────┴───────────────┐           ┌──────────────┴───────────────┐            ┌─────────────┴────────────────┐
                                                                                                                 │            TaxPage           │          │     GeneralExpensesPage      │     │            RentPage          │           │         HomeLoanPage         │            │            VehiclePage       │
                                                                                                                 ├──────────────────────────────┤          ├──────────────────────────────┤     ├──────────────────────────────┤           ├──────────────────────────────┤            ├──────────────────────────────┤
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │            ^_                  │            │                              │
                                                                                                                 │                              │          │                              │     │                              │           │                              │            │                              │
                                                                                                                 └────────────────────┬─────────┘  ┌───────┴──────────────────────────────┘     └──────────────────────────────┴┐          └───┬──────────────────────────┘            └────────────────┬─────────────┘
┌──────────────────────────────┐                ┌──────────────────────────────┐                                                      │            │                                                                            │              │                                                        │
│        UserIncome            │                │           IncomePage         │                                                      │            │                                                                            │              │                                                        │
├──────────────────────────────┤                ├──────────────────────────────┤                                                      │            │                                                                            │              │                                                        │
│                              │                │                              │                                                      │            │                                                                            │              │                                                        │
│                              │                │                              │                                                      │            │                                                                     ┌──────┴──────────────┴────────┐                                               │
│ +CalcIncome(double value)    │                │                              │                                                      │            │                                                                     │           PropertyPage       │                                               │
│                              ├────────────────┤                              │                                                      │            │                                                                     ├──────────────────────────────┤                                               │
│ +GetIncome():double          │                │                              ├─────────────────────────────────────────┐            │            │                                                                     │                              │                                               │
│                              │                │                              │                                         │            │            │                                                                     │                              │                                               │
│ +ToString():string <<override>>               │                              │                                         │            │            │                                                                     │                              │                                               │
│                              │                │                              │                                         │            │            │                                                                     │                              │                                               │
│                              │                │                              │                                         ├────────────┴────────────┴────┐                                                                │                              │                                               │
│                              │                │                              │                                         │       BudgetWindow           │                                                                │                              │                                               │
│                              │                │                              │                                         ├──────────────────────────────┤                                                                │                              │                                               │
└──────────────────────────────┘                └──────────────────────────────┘                                         │                              │                                                                │                              │                                               │
                                                                                                                         │                              │                                                                │                              │                                               │
                                                                                                                         │                              │                                                                │                              │                                               │
                                                                                                                         │                              │                                                                │                              │                                               │
                                                                                                                         │                              │                                                                └───────┬──────────────────────┘                                               │
                                                                                                                         │                              │                                                                        │                                                                      │
                                                                                           ┌─────────────────────────────┤                              │                                                                        │                                                                      │
                                                                                           │                             │                             ─┤                                                                        │                                                                      │
                                                                                           │                             │                              ├────────────────────────────────────────────────────────────────────────┘                                                                      │
                                                                                           │                             │                              │                                                                                                                                               │
                                                                                           │                             │                              │                                                                                                                                               │
                                                                                           │                             └────────────┬─────────────────┴───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
 ┌───────────────────────────────┐                ┌──────────────────────────────┐         │                                          │
 │         Savings               │                │           SavingsPage        │         │                                          │
 ├───────────────────────────────┤                ├──────────────────────────────┤         │                                          │
 │                               │                │                              │         │                                          │
 │                               │                │                              │         │                                          │
 │                               │                │                              │         │                                          │
 │                               ├────────────────┤                              │         │                                          │
 │                               │                │                              ├─────────┘                                          │
 │                               │                │                              │                                                    │
 │                               │                │                              │                                                    │
 │                               │                │                              │                                                    │
 │                               │                │                              │                                       ┌────────────┴─────────────────┐                ┌──────────────────────────────┐               ┌──────────────────────────────┐
 │                               │                │                              │                                       │           MainWindow         │                │           StatsWindow        │               │           FileIO             │
 │                               │                │                              │                                       ├──────────────────────────────┤                ├──────────────────────────────┤               ├──────────────────────────────┤
 └───────────────────────────────┘                └──────────────────────────────┘                                       │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              ├────────────────┤                              │               │                              │
                                                                                                                         │                              │                │                              ├───────────────┤                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         │                              │                │                              │               │                              │
                                                                                                                         └──────────────────────────────┘                └──────────────────────────────┘               └──────────────────────────────^_┘
~
~
```                                 
 
The user will be prompted with a window to choose between creating a budget or seeing the current months stats. If no text-files for the respective categories exist the stats window will return blank values. 
Overall compared to the CLI application, the process of entering values are far simplier and more fluid allowing you to go back and forth with a click of a button. The values entered are converted to a string formatted to the user's regional currency. 
 ## Roadmap
 * More optimising of the program. 
 * ~~Integrating new features such as a car financing and using generic collections over an array.~~
 * Use of more delegates to reduce boilerplate methods.
 * Add region relevant use of decimal points and not comma's.
 * ~~Eventually creating a GUI platform for the user to interact with, displaying data on graphs.~~
 * Adding a graph page to the stats window
 * Allowing user to check stats of previous months.
 * Better and more secure ways of reading and writing data

## Support and Possible FAQ

* Why do I get errors when I enter a decimal with a period (100.00)?  
As of now the American notation of comma's to separate decimals is used. Preference for period-decimals will be added soon. 
* Help it doesn't run  
Make sure .NET Framework 4.7.2 or later is installed. 
* Can I enter my own expenses?   
As of now, no. Future support might be intended though plans are in order of the roadmap.
* Why are stats blank?  
You need to add a new budget first, and click the confirm button to write the totalled value. 
* I keep getting a warning to enter a valid value, what does this mean?  
Your amounts are probably in the incorrect format, enter the number only.
* A month has passed and I can't access my old budget!   
A current flaw in version 3.0 will be ammended in the next version. 


 ## Contributing
Unfortunately this is a project for my programming course, so while this program is open-source, I must contribute entirely to it ;)
 ## Author
 Siegan Govender  
 20116858  
 Varisty College
 ## License
[MIT](https://choosealicense.com/licenses/mit/)

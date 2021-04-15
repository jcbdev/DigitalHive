# DigitalHive

Programming Challenge:
The coding test consists of building an Analytics Dashboard supported by REST Api and Database. It also includes creation of a python program to stitch the monthly contracts and produce a continuous timeseries applying a roll value and publish the results to the dashboard application. 

Expected:
	•	Implementation of the code using best practices like SOLID principles, design patterns and TDD or BDD.
	•	This solution should be returned in full 
	•	The approach and design decisions made during the development of the solution will be discussed in the next steps of the process.
	•	Code and Design should be flexible to allow any future commodities, models and metrics.

Python
	•	Price stitching program (Use InputRawData.xlsx):
	•	As the price of monthly contracts are different, stitch the prices to create a smooth continuous curve. This can be achieved in multiple methods. We are only interested in producing a smooth curve of Contract 1. Contract 2 data is provided to use it for generating the continuous timeseries of Contract1
	•	One of the methods you could use is below. You can use many other methods to produce a smooth curve. Below is just an e.g. of one of the methods. 
	•	to identify a roll timeseries – For all the historic period, on the day before the contract change calculate the roll as Contract1-Contract2.  Then cumulative sum of the roll value in reverse order (Latest date to historic) will be the final roll value series. 
	•	For all the contract changes, apply the roll value to the historic period to form a smooth curve. Contract1Series-RollValueSeries will give the smooth curve.

	•	Create code to publish the results to the Dashboard application:
	•	Create a function that would publish the results (ModelResults.xlsx) to the Dashboard application which can then be displayed as per below requirement.
	•	The derived metrics like Pnl YTD, Pnl LTD, DrawdownYTD can either be calculated in python before publishing to dashboard or in the REST API before displaying on the screen.

Angular Front End (React/Vue.js is acceptable)
Front End should be created in Angular 7+. Any libraries, like Bootstrap, high charts, ag grid can be used.
 
The dashboard should allow the following functionality (Can be in more than 1 screen). Please be aware that the end users of the application can be from different teams (E.g.: Management, Traders, Developer etc):
	•	Display key metrics. Use your experience to Identify the best way to display the key metrics for the user.
	•	PnL Daily
	•	Price
	•	Market/Commodity
	•	Model 
	•	Current Position – Tonnes/Lots
	•	Var Allocation – configure a fixed value (shouldn’t be hardcoded)
	•	Any other derived metrics – 
	•	Pnl YTD – Cumulative Sum of Daily Pnl in the year
	•	Pnl LTD – Cumulative Sum of Daily Pnl since beginning of the model
	•	DrawdownYTD = Is derived by subtracting the current PnlYTD from PeakValue of PnlYTD
	•	Display historical trend of the metrics using charts. Allow any interactive options for better analytics.  Multiple charts or combine 1 or more timeseries on one if they can be better analysed together.
	•	Historical PnL 
	•	Historical Position
	•	Drawdown timeseries

	•	Display last 5 days history of the key actions in a grid /html table E.g.: Allow filtering option by Model and Commodity.
	•	Model
	•	Commodity
	•	Prediction Trading Actions

C# REST API
Create a REST API using .net core version 2.1+
The API should serve below purpose:
	•	Save model results published from Python
	•	Return data to serve all the charts, table and any other data to the UI
	•	Handle any logic to create derived metrics.
 
Database
Use SQL Database for persistence with Entity Framework Core.
 
TDD/BDD
Code should be supported by any associated Unit tests/Jasmine  tests.

 
 



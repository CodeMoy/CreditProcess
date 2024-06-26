# CreditProcess
Project Name: - Credit Process
GitHub URL  : 
Project summary
The credit process is a single API project used to validate credit cards using the Luhn algorithm.
If we pass any credit card number, it will check whether it is a valid card number or no
Luhn Algorithm
1.	f the number already contains the check digit, drop that digit to form the "payload". The check digit is most often the last digit.
2.	With the payload, start from the rightmost digit. Moving left, double the value of every second digit (including the rightmost digit).
3.	Sum the values of the resulting digits.



API Endpoint : http://localhost:5035/api/CreditCard
                         Controller action method : ValidateCreditCard 
Instruction to run solution:
Step 1: Clone project using Git clone 
Step 2: Restore required packages 
Step 3: build and run the project (prefer IDE Visual Studio)
Step 4: In SwaggerUI add any credit card number and test it
 

Api End point: http://localhost:5035/api/CreditCard
Api method: Post
Request body:
{
  "cardNumber": "4012888888881881"
}
Response:
{
  "statusCode": 200,
  "message": "Valid card number!",
  "data": true
}


Technology Used
1.	Net 7 using c# language
2.	Version control Git
Project Structure:
I have completed the given verification process and already submitted it.
The project was created based on domain driven architecture but doesn’t all other layers like, repository, infrastructure etc.

Project Layer:
1.	CreditProcess.Api – Used to create public Api 
 
2.	CreditProcess.Domain – Used to create all domain and entities.

3.	CreditProcess.ApplicationCore - Used to create all business rules like service.
                      

Card validation logic has been written inside “CardValidationService” class 
 

Test Case result: 
There are two Xunit test projects used to cover api and service class 
1.	CreditProcess.Api.Test
2.	CreditProcess.Services.Test
 



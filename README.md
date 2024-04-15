# SE 4458 - Large Scale Systems - Midterm Project
# University Tuition Payment System
## Documentation
  ![login](https://github.com/gunesgultekin/4458_midterm/assets/126399958/141d1f1b-9339-4cbf-9a0a-c336e1d2354e)
* /login will generate a JWT token that will be used to reach endpoints
  /BankingApp/query tuition,
  /WebApp/addTuition,
  /WebApp/unpaidTuitions
  
![jwt](https://github.com/gunesgultekin/4458_midterm/assets/126399958/025f3f9c-ce8c-42b9-86b6-58fbc657e636)

* Enter the generated token in the authorization section on swagger

![banking-query](https://github.com/gunesgultekin/4458_midterm/assets/126399958/25d75a2a-084b-4c3f-8026-68f19bf633e1)

  * /BankingApp/queryTuition will return the total amount of tuition and current bank balance of the student with specified student number
  * 
![banking-pay](https://github.com/gunesgultekin/4458_midterm/assets/126399958/4ab29b89-6be0-4239-bdff-d5a3661ef0f4)

* If there is sufficient balance in the student's bank account, it records the payment of the specified amount (decreases the remaining tuition fee).
  
![mobile](https://github.com/gunesgultekin/4458_midterm/assets/126399958/52e17f2c-0c37-4ce3-bc09-5c644e46e9af)

* /MobileApp/queryTuition will return the total amount of tuition and bank balace of the student with given student number
  
![web-add](https://github.com/gunesgultekin/4458_midterm/assets/126399958/ef081dd0-a71f-4320-a611-d0823632153f)

* /WebApp/addTuition Records a tuition fee in the desired amount for the specified student number and education period.
  
![web-unpaid](https://github.com/gunesgultekin/4458_midterm/assets/126399958/d82abfb6-2f0b-4b45-9cdc-415a29718069)

* /WebApp/unpaidTuitions will return the list of students that has a unpaid tuition fee with specified term
  
![web-unpaid-paginated](https://github.com/gunesgultekin/4458_midterm/assets/126399958/3f17ff77-add8-4496-b981-93611782087a)

* /WebApp/unpaidTuitionsPaginated will return the list of students that has a unpaid tuition fee with specified term with 5 students per page
  

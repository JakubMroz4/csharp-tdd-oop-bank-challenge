# Domain Modelling

## Interfaces

### IBankAccount

| Property/Method                 | Scenario                                                        | Returns         |
| ------------------------------- | --------------------------------------------------------------- | --------------- |
| Id                              | stores Id of account                                            | Guid            |
| AccountNumber                   | stores public account number                                    | Guid            |
| OverdraftLimit                  | shows Overdraft limit of the account                            | Decimal         |
| AccountType                     | stores type of bank account                                     | AccountTypeEnum |
| Branch                          | stores branch of bank                                           | BankBranchEnum  |
| Person                          | accounts owner                                                  | Person          |
| GetStatement()                  | get account statement                                           | BankStatement   |
| GetBalance()                    | show account balance                                            | decimal         |
| AddTransaction(Transaction t)   | add transaction to account                                      |                 |
| RequestOverdraftLimi(decimal d) | rquest a change in accounts overdraft limit                     |                 |
| SetOverdraftLimit(decimal d)    | ChangeOverdraftLimit( used by accept method in OverdraftRquest) |                 |

### ITransaction

| Property/Method | Scenario                                   | Returns             |
| --------------- | ------------------------------------------ | ------------------- |
| Id              | stores Id of transaction                   | Guid                |
| Account         | stores account which made the transaction  | Guid                |
| Value           | amount of funds                            | decimal             |
| Type            | type of transaction (deposit / withdrawal) | TransactionTypeEnum |
| Date            | date of transaction                        | DateTime            |
| SetAccount()    | assing account to transaction              |                     |

### IPrinter
| Method  | Scenario                  |
| ------- | ------------------------- |
| Print() | prints the bank statement |




## Inheriting Classes

### BankTransaction : ITransaction
### CurrentBankAccount : BankAccount
### SavingsBankAccount : BankAccount

### TwilioPrinter : Printer

### EmptyTransactionException : Exception
### NotEnoughFundsException : Exception
### TransactionAlreadyHasOwnerException : Exception


## Other classes

### BankStatement

| Property/Method         | Scenario                                     | Returns |
| ----------------------- | -------------------------------------------- | ------- |
| Print(IPrinter printer) | prints the bank statement with given printer |         |
| ToString()              | returns the bank statement in string format  | string  |

### OverdraftRequest

| Property/Method | Scenario                        | Returns |
| --------------- | ------------------------------- | ------- |
| Account         | stores the account id           | Guid    |
| Amount          | stores overdraft request amount | decimal |
| Accept()        | overdraft request accept method |         |

### Person

| Property/Method | Scenario              | Returns |
| --------------- | --------------------- | ------- |
| Id              | id of the person      | Guid    |
| Name            | name of the person    | string  |
| Address         | address of the person | string  |

## Static classes

### BankAccounts

| Property | Scenario                 | Returns            |
| -------- | ------------------------ | ------------------ |
| Accounts | stores all bank accounts | List\<IBankAccount> |

### OverdraftRequests

| Property/Method  | Scenario                                         | Returns                |
| ---------------- | ------------------------------------------------ | ---------------------- |
| Requests         | List of overdraft requests                       | List<OverdraftRequest> |
| GetRequest(guid) | searches for request for given bank account guid | OverdraftRequest       |
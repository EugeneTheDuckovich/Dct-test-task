# DCT_test_task
This is a test task for Digital Cloud Technologies.
The task is a window application developed using .NET and WPF, that shows data about cryptocurrencies using open APIs.

# Functionality of application
-CoinCap API was selected as core and only API that is used in this project.

-Main page of application includes data grid that shows general information about top 10 currencies, using /assets endpoint of CoinCap API. 
User can find a currency that they are interested in using search by name of currency or its symbol.

-Details page contains detailed data about particular currency, including name, id, symbol, price, market cap, price change over the last 24 hours in percents
and trading volume over the last 24 hours in USD. This is done via /assets/{id} endpoint.
This page also includes a lsit of exchanges where this currency may be bought and for what price, which is done with the help of /assets/{id}/markets endpoint.

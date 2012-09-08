
CSharp.Zugmonitor
=========

# Introduction
CSharp.Zugmonitior is a client library for the zugmonitor API from zugmonitior.sueddeutsche.de


# Usage
1: Create an ServerProvider object, this handles all the communication with the backing service and deserilizes the result.

```c#
var service = new ServiceProvier();
```
1.1: Internally the ServiceProvider uses a synchronus WebRequst to get data from the service, if you want to change that
you can use an alternate constructor that takes a Func<uri,string> to handle the request.

```c#
var service = new ServiceProvider(uri => //do some black magic here);
```
2: Get all stations.

```c#
var stations = service.GetStations();
```

3: Get all trains for a specific date

```c#
//Se need a date on which we would like to get the information.
//Supply DateTime.Now for the current real time state of the trains.
//The day, month and year are enought, all time data is ignored by the service.
var date = new DateTime(2012, 9, 3);
var trains = serice.GetTrains(date);
```

4: Fork it, have fun, use the data to create awesome applications.
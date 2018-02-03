# Using EventAggregator
This is a new implementation with the same functions as the original sample "[Using EventAggregator](https://github.com/PrismLibrary/Prism-Samples-Forms/tree/master/UsingEventAggregator)". Due to some old nuget packages and lagacy projects from original solution, upgrading from orignial repository might take more work so I create new solution instead. 

**Note:** The rcommended minimum version of Visual Studio 2017 is v15.4.2

**Note:** UWP requires Falls Creators Update v10.0.16299.0

**Note:** The Xamarin.Forms templates requires the latest version of Xamarin to be installed

I used VS2017 vertion 15.5.6 to implement this. 

----------


In this sample, we will see how to create custom events, how to pass custom payload in events, how to subscribe to events both inside Xamarin.Forms app and on the native platform, and how to publish events all using Prism's EventAggregator.

## Creating Events
To create an event, simply extend `Prism.Events.PubSubEvent<T>` with a T payload.

```csharp
public class IsFunChangedEvent : PubSubEvent<bool> { }
```
### Usage
#### Publish
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (true);
```
#### Subcribe
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) 
{
    // Do something with the payload
}
```

## Creating Events with Custom Payload
To create a custom payload for your event, simply extend `System.EventArgs` and set as payload for custom event,
```csharp
public class NativeEventArgs : EventArgs
{
    public string Message { get; set; }
    public NativeEventArgs (string message)
    {
        Message = message;
    }
}

public class NativeEvent : PubSubEvent<NativeEventArgs> { }
```
### Usage
#### Publish
```csharp
_eventAggregator.GetEvent<NativeEvent> ().Publish (new NativeEventArgs("Xamarin.Forms"));
```

#### Subcribe
```csharp
_eventAggregator.GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);

void OnNameChangedEvent(NativeEventArgs args) 
{
    Message = args.Message;
}
```

## Subscribing To Events
As mentioned above, subscribing to events is quite simple inside Xamarin.Forms app.
```csharp
_eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);

void IsFunChanged(bool arg) 
{
    // Do something with the payload
}
```
### Platform Subscriptions
To subscribe to an event published in Xamarin.Forms app at the platform level, resolve the `IEventAggregator` from the `Xamarin.Forms.App()` instance before loading it.

### iOS
After initializing the Xamarin.Forms app in `FinishedLaunching()` method of `AppDelegate.cs`,
```csharp
var application = new App (new iOSInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent>().Subscribe(OnNameChangedEvent);
LoadApplication (application);
```

### Android
After initializing the Xamarin.Forms app in `OnCreate()` method of `MainActivity.cs`,
```csharp
var application = new App (new AndroidInitializer ());
var ea = application.Container.Resolve<IEventAggregator> ().GetEvent<NativeEvent> ().Subscribe (OnNameChangedEvent);
LoadApplication (application);
```

### UWP
After initializing the Xamarin.Forms app in `OnLaunched()` method of native `App.xaml.cs`, subsribe in the contructor of `MainPage.xaml.cs`,
```csharp
var application = new UsingEventAggregator.App(new UwpInitialer());
var ea = application.Container.Resolve<IEventAggregator>().GetEvent<NativeEvent>().Subscribe(OnNativeEvent);
LoadApplication(application);
```

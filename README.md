# LFP-Tool

Long File Path enabling tool will allow for quickly and easily enabling the
Windows 10 Long File Path option. This tool will update the registry key
that enables the Long File Path option which is now supported in Windows 10.

The tool will check the current state and allow you to switch between the
Long File Path option being Enabled or Disabled easily. If it is changed,
the tool will prompt to reboot the computer to enable the option. This
is optional and can be skipped if necessary.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 
See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You will need to Microsoft .NET Framework v4.5.1 or higher in order to run LFP-Tool

### Installing

Once compiled, simply run the Executable. You will be prompted to elevate access as the tool requires "Run as Administrator" privileges. 
This is in order to allow the application to edit the HKEY_LOCAL_MACHINE Registry Hive.

## Built With

* Microsoft Visual Studio 2017 - Visual Basic

## Contributing

N/a

## Versioning

N/a

## Authors

* **Optoisolated** - *Initial work* - [Optoisolated](https://github.com/Optoisolated)

See also the list of [contributors](https://github.com/optoisolated/LFP-Tool/contributors) who participated in this project.

## License

This project is closed license - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* This program was developed to help the folks at the office with migrating to Sharepoint/OneDrive for document management.
* Windows 10 still has a 250 Character Limit for path names for some reason. 
* You can make it longer now, but you have to enable it.

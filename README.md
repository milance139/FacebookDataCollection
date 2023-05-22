Facebook Data Collection and Management Task

This is a web application that allows you to read a collection of data from the Facebook Graph API, present the data on the application front-end, make changes to the collection via a web page, and save the changes into a JSON file on disk. Additionally, it supports authentication with Facebook for enhanced security.
Prerequisites

Before running the project, ensure that you have the following prerequisites installed on your machine:

    Visual Studio (version XYZ) with .NET Framework 4.7.2.
    Facebook App Credentials: Create a Facebook App and obtain the App ID and App Secret.

Getting Started

To get started with the project, follow these steps:

    Clone the repository to your local machine.
    
    Open the solution file (FacebookDataCollection.sln) in Visual Studio.

    In Visual Studio, restore the NuGet packages for the solution.

    Open the Web.config file and update the Facebook:AppID and Facebook:AppSecret sections with your Facebook App credentials.

    Build and run the application using Visual Studio.

    Your default web browser should open, and you can access the application at the specified URL.

Usage

    On the home page, click on the "Login with Facebook" button to initiate the Facebook authentication process.

    You will be redirected to the Facebook login page. Enter your Facebook credentials and authorize the application to access your data.

    After successful authentication, the application will retrieve data from the Facebook Graph API and display it on the front-end in HTML form.

    Make changes to the data collection via the web page by editing the corresponding fields and submitting the form.

    Upon submitting the form, the changes will be saved into a JSON file on disk.

    You can view the updated JSON file by navigating to the file path specified in the Web.config configuration.

Authentication

The application uses Facebook authentication to ensure secure access to the Facebook Graph API data. When prompted, click on the "Login with Facebook" button and enter your Facebook credentials to authenticate and gain access to the data collection.
Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

    Fork the repository.

    Create a new branch for your feature or bug fix.

    Make the necessary changes and commit your code.

    Push your branch to your forked repository.

    Open a pull request in this repository, and provide a clear description of your changes.

Acknowledgments

    Facebook for Developers Documentation
    Microsoft Docs - ASP.NET MVC

Contact

If you have any questions or suggestions, feel free to contact us at milance139@outlook.com

Feel free to modify the README file as per your project requirements and add any additional sections or instructions you think are necessary.

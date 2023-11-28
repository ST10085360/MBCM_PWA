# MBCM Volunteer Portal

## Overview

Welcome to the MBCM Volunteer Portal, a Progressive Web Application designed to gain in-depth information about Mandela Bay Community Movement organization, facilitate volunteer engagement and community projects. This portal allows users to log in, register, explore community projects, and participate as volunteers to join community projects just to name a few.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [User Registration Page](#user-registration-page)
- [User Login Page](#user-login-page)
- [Volunteer Portal Home Page](#volunteer-portal-home-page)
- [Active Community Projects](#active-community-projects)
- [Community Feed](#community-feed)
- [Account Dashboard Page](#account-dashboard-page)
- [Frequently Asked Questions (FAQ) Page](#frequently-asked-questions-faq-page)
- [Admin Dashboard Page](#admin-dashboard-page)
- [License](#license)
- [Contact](#contact)

## Features

- **User Authentication:** Secure login and registration system for users.
- **Project Exploration:** Browse and join active community projects.
- **Volunteer Engagement:** Easily participate in projects and contribute to community development.
- **Guest Access:** Option to continue as a guest for a quick overview.

## Getting Started

### Prerequisites

- [Dotnet SDK](https://dotnet.microsoft.com/download) - Make sure you have .NET SDK installed.
- Visual Studio 2022

### Installation

1. Clone the repository:
2. Build and run the project.
3. Open your web browser and visit http://localhost:5000 to access the MBCM Volunteer Portal.

## User Registration Page

This page allows users to register for an account on the MBCM volunteer portal. Users can enter their information, including email, name, bio, phone number, and password, to create an account.

### Features

- User-friendly registration form.
- Input validation for email, name, bio, phone number, and password.
- South African phone number validation using regex pattern.
- Registration button to create a new user account.
- Redirect to the "/projects" page upon successful registration.

### Usage

1. **Accessing the Registration Page:**
   - Navigate to Register link in Login page to load registration page and enter required details.

2. **Completing the Registration Form:**
   - Enter your email, first name, last name, bio/description, phone number, and password.
   - Ensure that all fields are filled correctly, and validation messages are addressed.

3. **Registering a New Account:**
   - Click the "Register" button to create a new user account.
   - Upon successful registration, you will be redirected to the "Home" page.

4. **Handling Errors:**
   - If there are any registration errors, appropriate error messages will be displayed.

## User Login Page

This page allows users to log in to the MBCM volunteer portal. Users can enter their email and password to access their accounts. Additionally, there is an option to continue as a guest.

### Features

- User-friendly login form with input fields for email and password.
- Error message display for failed login attempts.
- "Login" button to authenticate users and redirect them to the "Home" page upon successful login.
- "Continue as Guest" button to access the portal without logging in.

### Usage

1. **Accessing the Login Page:**
   - The application will load this page upon startup.

2. **Logging In:**
   - Enter your email and password in the respective input fields.
   - Click the "Login" button to authenticate your account.
   - Upon successful login, you will be redirected to the "Home" page.

3. **Guest Access:**
   - If you prefer not to log in, you can click the "Continue as Guest" button to access the portal as a guest.

4. **Handling Errors:**
   - If there are any login errors, an appropriate error message will be displayed.

## Volunteer Portal Home Page

The page provides information about MBCM (Mandela Bay Community Movement) and invites individuals and groups to become volunteers (guests only). This page serves as a gateway for those interested in contributing to the community, learning about and joining the MBCM movement.

### Features

- Display of MBCM's establishment and mission.
- Information on community transformation and the impact of volunteer participation.
- Invitation to join MBCM and become part of the community transformation process.

### Usage

1. **Accessing the Volunteer Portal:**
   - Navigate to the "Home" page from the main portal navigation.

2. **About MBCM:**
   - Learn about MBCM's establishment, mission, and the need for dedicated citizens in local governance.

3. **Community Transformation:**
   - Explore the potential impact of diverse individuals and groups coming together for community transformation.

4. **Join Us:**
   - Understand the invitation to join MBCM and become actively involved in strategic planning and guidance for Independent Candidates.

5. **Our Belief:**
   - Discover MBCM's belief in the power of committed private citizens to provide solutions to challenges facing the Metro.

6. **Empowering Stakeholders:**
   - Learn about MBCM's advocacy for stakeholders to lead the decision-making process in the city.

## Active Community Projects

The "Projects Feed" page displays active community projects available for volunteers to join. Users can view project details and send requests to join projects they are interested in.

### Features

- List of active community projects.
- Project details including title, start date, location, and member count.
- Ability for users to send requests to join projects.
- Visual indication of the request status for each project.

### Usage

1. **Accessing the Projects Page:**
   - Navigate to the "Projects Feed" page from the main portal navigation.

2. **Viewing Projects:**
   - Explore the list of active community projects (guests and volunteers).
   - Review project details, including title, start date, location, and member count.

3. **Sending Join Requests:**
   - Click the "Request to Join" button for a project to express your interest (volunteers only).
   - If already joined or a request is pending, appropriate status indicators will be displayed.

## Community Feed

This page allows users (admin or volunteers) to view and manage community project suggestions.

### Features

- View a list of project suggestions.
- Add a new project suggestion.
- Delete project suggestions (admin only).

### Usage

1. **Viewing Suggestions:**
   - Access the "Suggestions" page from the main portal navigation.
   - Browse through the list of suggested projects.
   - If you're an admin or volunteer, you can see additional options:
     - "Add Project Suggestion" button.
     - "Delete" button for each suggestion (admin only).

2. **Adding a Project Suggestion:**
   - Click on the "Add Project Suggestion" button.
   - Fill in the required details (Title, Description, Location) in the form.
   - Click the "Add Project" button.
   - The new project suggestion will be added to the list.

3. **Deleting a Project Suggestion (Admin Only):**
   - Click the "Delete" button next to the project suggestion you want to delete.
   - A confirmation modal will appear.
   - Confirm deletion to remove the suggestion.

## Account Dashboard Page

This page provides an overview of the user's account details and, for volunteers, their associated projects.

### Features

- Display of user details (Name, Email, Phone Number).
- Display of projects associated with the user (for volunteers).

### Usage

1. **Accessing the Page:**
   - Navigate to the "Account Dashboard" page by clicking "Account" from the main portal navigation.
   - Ensure you are logged in as a registered user (not a guest).

2. **Viewing Account Details:**
   - User details such as name, email, and phone number are displayed.

3. **Viewing Associated Projects (For Volunteers):**
   - For volunteers, a section displays projects they are part of.

## Frequently Asked Questions (FAQ) Page

This page provides answers to common questions users may have about the community project portal.

#### Features

- Display of frequently asked questions.
- Accordion-style interface for easy navigation.

#### Usage

1. **Accessing the FAQ Page:**
   - Navigate to the "FAQ" page from the main portal navigation.

2. **Viewing Questions and Answers:**
   - The page presents a list of frequently asked questions.
   - Click on a question to reveal its answer.
   - The accordion-style interface allows for easy navigation.

## Admin Dashboard Page

The "Admin Dashboard" page is accessible only to administrators (users with the "Admin" role) and serves as an administrative panel to manage active projects, project requests, and user accounts. Administrators can view and delete projects, handle project requests, and manage user accounts.

### Features

1. **Active Projects:**
   - View a list of active projects, including project title, description, and members.
   - Remove a user from a project.
   - Delete a project.

2. **Project Requests:**
   - View pending project requests.
   - Accept or decline project requests.

3. **User Management:**
   - View a list of users with their names, emails, and phone numbers.
   - Delete user accounts.

### Usage

1. **Accessing the Admin Projects Page:**
   - Only users with the "Admin" role can access the "Admin Dashboard" page.

2. **Active Projects Section:**
   - View a list of active projects.
   - Click "Add New Active Project" to navigate to the page for adding a new project.

3. **Removing User from Project:**
   - Click the "X" button next to a user's name in the "Members" section to remove them from the project.
   - Confirm the action in the displayed modal.

4. **Deleting Project:**
   - Click the "Delete Project" button to delete a project.
   - Confirm the action in the displayed modal.

5. **Handling Project Requests:**
   - View project requests in the "Project Requests" section.
   - Click "Accept" or "Decline" to handle a request.

6. **User Management:**
   - View user accounts in the "Users" section.
   - Click the "X" button to delete a user account.
   - Confirm the action in the displayed modal.

### License
This project is licensed under the MIT License - see the LICENSE file for details.

### Contact
If you have any questions or suggestions, feel free to reach out to us at 083 444 1618 or info@mbcm.org.za

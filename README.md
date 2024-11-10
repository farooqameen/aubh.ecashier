# **Web-based Financial Management System**

# Executive Summary

This technical report details the development and implementation of a
web-based financial management system, dubbed "eCashier", for the
finance department. The project was initiated in response to critical
limitations identified in the existing financial management
infrastructure. The previous system's inflexibility and outdated
architecture prevented the implementation of necessary customizations
and the direct access of crucial database information, significantly
hampering operational efficiency.

The new eCashier system addresses these challenges through a modern
solution that emphasizes user control and data accessibility. The
implementation offers industry-standard security protocols while
maintaining the flexibility required for day-to-day operations.

This report provides a comprehensive overview of the project's
methodology, implementation details, and outcomes, serving as both
documentation of the development process and a blueprint for future
system enhancements.

# 1. Introduction

## 1.1 Background

The eCashier serves as a financial transaction platform for the
university community, facilitating student payments across various
institutional services and products, including but not limited to:

-   Academic-related payments

-   Administrative fees

-   Fines and late payments

-   University merchandise

Due to the inherent sensitivity of the current financial management
infrastructure, minimal information was provided during the initial
consultations. Most requirements were delivered through a series of
online meetings, highlighting key features required in the new system. A
small number of screenshots detailing the current system's operations
were provided as a point of reference for critical business operations.

While the legacy system often required manual intervention for payment
processing, the new system must leverage a payment gateway API. This
integration allows for automatic handling of transactions among local
and international payment providers, with built-in invoice generation
and transactional updates.

## 1.2 Problem Statement

-   Current system challenges

    -   The current finance system was a rushed implementation during
        COVID, with very basic features and minimal customization.

    -   Direct access to the databases behind the current finance system
        was not provided, severely impeding other implementations.

    -   Granular system control is not available, posing as a security
        risk for inter-department communication.

-   Need for automation and modernization

    -   Further enhancements are required to meet business growth, which
        is not feasible due to the old architecture implemented.

## 1.3 Project Objectives

-   Primary objective:

    -   Design and develop a web-based financial management system.

-   Secondary objectives:

    -   Ensure the confidentiality, integrity and availability of user
        data.

    -   Enhance data security through server-sided handling.

    -   Automate transaction processing through the payment gateway API.

    -   Provide granular control over system functionality.

## 1.4 Project Scope

-   System development:

    -   Development of an ASP.NET web application.

    -   Integration with a Microsoft SQL database.

    -   Implementation of role-based access control.

-   Financial processing:

    -   Integration with payment gateway API.

    -   Real-time transaction processing.

    -   Support for multiple payment methods.

-   Security implementation:

    -   Implementation of HTTPS protocol.

    -   Validation checks with session management.

# 2. Literature Review

## 2.1 Current Financial Management Systems

Financial Management Systems (FMS) are available either as standalone
solutions or integrated within Enterprise Resource Planning (ERP)
systems. This review examines the characteristics and implications of
both systems for business operations.

Modern FMS solutions are designed to streamline financial operations
through core accounting capabilities. They may provide advanced
financial reporting and analysis to help businesses make data-driven
decisions or allow system users to export data for external processing.

Compared to traditional ERP systems, FMS solutions often have lower
initial costs, making them more accessible for businesses of all sizes.
The shorter implementation timeframes come with reduced training
requirements, allowing for business processes to continue undisrupted.

However, these systems contain limited API accessibility, further
constraining implementation and automation with other business
applications. Due to the nature of the solution provided, advanced
customization features might be unavailable.

With an ever-growing business, certain requirements may change over
time, requiring an overhaul of implemented systems. Modularity is a key
component of a changing landscape, which would require cross-system
synchronization with complex structures. Standalone systems by nature
are isolated, which could lead to a rapid decline in functional
usability across an organization.

On the other hand, ERPs focus on seamless cross-module data flow,
ensuring smooth operations with minimal data redundancy. This
integration is supported through a consistent user interface across
functions, which enhances usability and provides a familiar workflow.

The extended functionality provided includes comprehensive accounting,
financial management, customer relationship management, and more. These
modules often offer advanced analytics and reporting and can handle
complex operations like supply chain and human capital management.

Given the large scope of ERP systems, these integrated modules might
serve as a replacement for currently implemented systems, eliminating
heterogeneity. While suitable for starting businesses that aim for an
all-in-one solution, most ERP systems far exceed the specific
requirements of an FMS system and may constitute as information overload
in terms of product features.

The choice between a standalone FMS or an ERP based solution should be
based on a thorough analysis of organizational needs, resources, and
long-term strategy. These evaluations may lead towards the need for a
custom-built system that would provide more functionality than a
standalone FMS, while avoiding unnecessary modules in an ERP.

# 3. Methodology and Project Plan

## 3.1 Development Methodology

The development methodology follows an iterative approach heavily
inspired by successful game development by Valve Studio and Zoteling.
The core principles revolve around rapid prototyping and testing, where
each feature or functionality is developed as a minimum viable product,
and then refined through rigorous implementation and testing. This
approach prioritizes functionality and usability of components over
theoretical design, ensuring that each addition provides significant
value to the user's use case.

The development cycle consists of three interconnected phases:
prototyping, user testing, and refinement. In the prototyping phase, new
features are implemented with basic functionality and minimal
interfaces. These prototypes are immediately subjected to user testing
sessions, where interactions, performance metrics, and feedback are
immediately observed. In doing so, necessary adjustments can be made
extremely quickly, ensuring that the application's desired flow is
maintained throughout development.

This refinement enhances the quality and structure of each component,
aiming to reach the required quality threshold. This cycle continues
throughout development, with features being continuously optimized and
integrated into the larger application architecture.

It can also be noted that such approach can significantly cut down on
design and planning, as multiple variants of a single component can be
made for comparison studies. While managing multiple component versions
requires heavy version control, this approach leads to better design
choices and ultimately results in features that more closely align with
the end user's needs and preferences.

## 3.2 Technology Stack

-   Framework and server-side handling

    -   ASP.NET Core Razor Pages

    -   ASP.NET Identity

    -   Written in C#

-   Client-side handling

    -   JavaScript

    -   jQuery

    -   AJAX

-   API HTTP calls

    -   RestSharp

-   Styling

    -   CSS

    -   Bootstrap 5

ASP.NET Core is a .NET web development framework initially designed by
Microsoft and is currently open source for community development. Razor
Pages is a templating engine around the Model-View-Controller (MVC)
paradigm, with key changes for a simpler development process.

In traditional MVC (Model-View-Controller) programs, the application
logic is divided into three distinct components. However, Razor Pages
simplifies this structure by merging the View and Controller aspects
into a single component called the PageModel.

A PageModel consists of two files:

1.  A .cshtml file, which contains the HTML markup needed to render the
    page\'s components.

2.  A .cs file, which contains the C# code that handles the logic and
    page interactions.

The consolidated PageModel allows for rapid prototyping of a single
page, without the need for globally defined queries and data handling.

jQuery and AJAX are JavaScript frameworks that help with client-side
validation and verification and provide much-needed dynamic components
to a static page. A clear example is the implementation of
intl-tel-input, a JavaScript plugin for international telephone input
and validation.

While HTTP calls can be natively written in C#, RestSharp provides a set
of well-defined, easy-to-use sync and async function calls to remote
resources or states. Coupled with clear and updated documentation, it
becomes a leading choice in complex API integration for a finance
management system.

Bootstrap 5 has become a common frontend toolkit, aiming to enhance the
quality of web pages through extensive style classes and built-in
formats. Given the variety of web-capable devices, consistent formatting
can be achieved through the addition of complimentary breakpoints and
appropriate sizing.[]{#security-implementation .anchor}

# 3. Progress and Implementation



# 4. Reflections and Conclusion

The overall progress of this project has been steady and consistent,
with required implementations being added and tested on a weekly basis.

Multiple challenges have been identified throughout the development
process, such as:

-   Database initialization

-   Dropdown list population

-   Model-binding across different components

-   Many-to-many relationships between inventory items and orders

-   Scaffolding Create-Read-Update-Delete (CRUD) pages

-   Session management between the landing page and the summary page,
    including looping references

-   Validation and verification of the price value

-   Table header and body formatting

The provided methodology allows for continuous development without long
periods of stagnation on a single component. On many occasions, problem
solving and tinkering is left for another time, due to the inherent
stress of debugging and solving issues as opposed to the development of
new components.

This has significantly increased productivity and reduced the effect of
fear-paralysis over the long term, with much of the credit given to the
gratification of creating a new feature or meeting functional
requirements.

# 5. References

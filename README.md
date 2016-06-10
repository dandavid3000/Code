>For those who may concern about my work I have been doing during my study. This folder contains many different subfolders storing various projects. There are my 6-month internship at SAP Labs France, Eurecom semester project, exercises as well as projects relating to software development in different programming languages.

#Introduction
Most of the projects I mainly finished in `C/C++` or in `Java`. `Python` is a new language that I've had a chance to access recently since my Master's program at Eurecom under courses such as `Secure System`, `SoftDev`, and `Forensics`. I'm really interested in this language, still studying it, and catching up. 

p/s Some projects you'll find strange because they're not in English. I am still working on them.

## Table of contents
* [Secure integration of Internet of Things](#secure-integration-of-internet-of-things)
* [Attack Crawler for Modern Networked Systems](#attack-crawler-for-modern-networked-systems)
* [Projects in C/C++](#projects-in-c-and-c-plus-plus)
* [Projects in Java](#projects-in-java)
* [Projects in Python](#projects-in-python)
* [Projects in CSharp](#projects-in-sharp)
* [Projects in Visual Basic](#projects-in-visual-basic)
* [Web projects](#web-projects)
* [What comes next](#what-comes-next)

## Secure integration of Internet of Things
I participated in a co-innovation project named [Secure Integration of Internet of Things](http://scn.sap.com/community/labs/blog/2015/06/25/co-innovation-project-on-predictive-analytics-for-pipeline-integrity). The requirements come from French Public Sector - City of Antibes. They'd like to have an end-to-end solution for data collected by more than 2000 sensors, and deployed for their water network. They use the data for `predictive maintenance` to predict the pipeline failures of the water network. In order to improve management, and financial optimization, they also would like to visualize their water network. The data will be encrypted at the beginning, and only decrypted at the end. In particular, I designed and implemented a sysmetrical cryptography to assure the confidentiality and integrity of the data accross many different platforms including `Arduino` (C/C++), `Raspberry` and `Intel Edision` (Python), `DataGraph application` and `FreeDataMap` (Java, and Javascript). Setup a connection between `PLCs`, `SIGFOX`, and `HANA Cloud Platform`. The final step of this project is to evaluate the security perspective. I built an attack tree containing attack models, and considered all possible attacks that could happend to the system, and provided suggestions on how to defend, and mitigrate those risks.

![Architecture](https://github.com/dandavid3000/Code/blob/master/images/architecturediagram.png "Architecture Overview")


I am so sorry to say that this project is confidential. Therefore, I cannot reveal the information. However, if you are interested in this project, I have a **presentation file** [here](https://github.com/dandavid3000/Documents/blob/master/SecureIoT/SAP_Defense.pptx) which I used for my defense, and for some demo videos you can contact me directly via my email address. I also completed an Enterprise Github about this work to help others can replicate my concept, as well as a detailed report with more than 150 pages.

At the end, the concept worked perfectly, it's considered to develop and deloy as a real bussiness.

![Application demo](https://github.com/dandavid3000/Code/blob/master/images/Concept.png "Application demo")

I am really into this project because it brought me a lot of experiences. I could improve my programming skills, and learnt new languages, platforms. In addition, I had a chance to improve my communication skills by communicating directly to the stakeholders in a multicultural environment, and access new modern technologies.

## Attack Crawler for Modern Networked Systems
Because we have a large scale attacks on networked systems have been conducted in recent year. Unfortunately, to study and analyse those attacks is quite complex, and requires gathering information from very diverse sourses.
The objective of this project is to evaluate which relevant information can be exracted from the internet and provided to users.
In particular, we developed a security feature for [TTool](http://ttool.telecom-paristech.fr/) which is an open-source software, and it's developed by professor [Ludovic Apvrille](http://perso.telecom-paristech.fr/~apvrille/) at Telecom ParisTech.

The project was divided into two main parts. Web crawler, and The assistant; a friendly interface which allows users to retrieve relevant information from the Database (Web crawler).

Regarding to our work in this projects:
* Studied, analysed, and illustrated a well-known attack [Stuxnet](https://en.wikipedia.org/wiki/Stuxnet) as a SysML-Sec attack model.
* Implemented a friendly user interface for users to retrieve information, perform the search
* Designed, and implemented a secure protocol as a bridge to let TTool, and The Crawler interact together.

The **final report** for this work is available [here](Java/Eurecom/SemesterFinalResult/FullSubmitted_Source/SemesterProjectReport_VO.pdf) along with the [source code](Java/Eurecom/SemesterFinalResult/FullSubmitted_Source/TTool.zip). The protocol is developed step by step, and stored [here](Java/Eurecom/SmallClient_Server/) from the simple one from multithreaded to the version that uses SSL socket.

## Projects in C and C plus plus
## Projects in Java
## Projects in Python
## Projects in CSharp
## Projects in Visual Basic
## Web projects
## What comes next
I hope you will see more interesting projects in the near future. Currently, I am looking for a new challenge to start my career since I'm passionate about **software development**, **Internet of Things**, and **Security**.

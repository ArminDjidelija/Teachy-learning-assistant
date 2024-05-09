# # Teachy - Your learning assistant with AI
Teachy is learning assistant which offers students and professors to share documents, do online tests, to provide insightful AI response to students based on their test results, to provide AI help to professors about questions students usually fail on their online tests including corresponding materials for that questions. Also, professors can create whole test with questions and answers based only on PDF document they upload for specific subject.
This project was made during 24' Hackathon organised by local organisation BEST Group in Mostar with this year's theme "Use of AI in education". For that purpose we created Teachy - Learning assistant and Management system for schools and universities.
This project was made by 
- [Zaim Mehić](https://github.com/zmehic)
- [Ensar Čevra](https://github.com/EnsarCevra)
- [Nedim Mustafić](https://github.com/nddim)
- [Adnan Humačkić](https://github.com/AdnanHumackic)
- [Armin Đidelija](https://github.com/ArminDjidelija)

# AI and Teachy
Teachy uses AI (GPT-3.5 Turbo) to give students and teachers personalized answers and messages. Students  and professors can use Teachy to answer anything related to school. Teachers can see in which questions and tests students are mostly failing, and get personalized message and corresponding documents. Teachers can create new tests using AI which creates new questions and answers based on PDF documents teacher upload. Also, AI is used for automatic scoring points for "essay" questions, or questions where students must give an answer in form of a text. 

## Teachy for students
Asking Teachy about Pythagoras theorem:
![Odgovor1video-MadewithClipchamp-ezgif com-video-to-gif-converter (1)](https://github.com/ArminDjidelija/hackathon/assets/110191710/81a5eefb-320e-4d13-bbb9-11705b957382)

Asking Teachy  about something not related to school:
![Odgovor2video-MadewithClipchamp-ezgif com-crop (1)](https://github.com/ArminDjidelija/hackathon/assets/110191710/20dca2d3-40e2-4670-8641-8ecf385ef344)

Searching documents for subjects:
![Materijalivideo-MadewithClipchamp-ezgif com-video-to-gif-converter](https://github.com/ArminDjidelija/hackathon/assets/110191710/86f62ced-ca06-47ab-ba6e-434bbc1a4b87)

Online test in action:

![Test-MadewithClipchamp1-ezgif com-video-to-gif-converter](https://github.com/ArminDjidelija/hackathon/assets/110191710/7105b43f-db07-4d41-a7c7-d76e71d12550)


## Teachy for professors
Reviewing subjects and analyzing data:
![Profesortestovi-MadewithClipchamp-ezgif com-video-to-gif-converter](https://github.com/ArminDjidelija/hackathon/assets/110191710/fe357737-994a-4f73-a6a9-3f7a13746ee6)

Reviewing questions and adding new questions with AI:
![Pitanjaaiprofesor-MadewithClipchamp-ezgif com-video-to-gif-converter](https://github.com/ArminDjidelija/hackathon/assets/110191710/a7a18b1a-8d21-4d4c-a9be-1e6ea095a3fd)

Reviewing tests results and grading answered questions with AI:
![Testoviaiocjenjivanjeprofesor-MadewithClipchamp-ezgif com-video-to-gif-converter](https://github.com/ArminDjidelija/hackathon/assets/110191710/d7a71d22-5028-44e6-911f-e17cd7c549c1)

## Technologies used
OpenAI, Angular, ASP.NET Core, SQL, HTML, CSS, JS, TS, Bootstrap
## Instructions for use
- Start HackathonBest24.sln from Backend directory
- Inside package manager console insert command: update-database
- Start the project
- Call the controller /api/podaci using Swagger or with the link: https://localhost:7020/api/Podaci
- Call the controller /UradeniTestoviPodaciGenerator using Swagger or with the link: https://localhost:7020/UradeniTestoviPodaciGenerator
- Go to the folder Frontend and execute the command "npm install"
- Start the application with command "ng serve"
- Login data for student:
    email: adnan@edu.fit.ba
    password: adnan
- Login data for professor:
    email: denis@edu.fit.ba
    password: dena
## Conclusion
During this hackathon we had a little over 30 hours to come up with project idea, implement the project and create presentation. We managed to make effective software tool which successfully uses AI to make it easier and more effective for students and professors to learn and teach. We are proud of this project since we managed to it in such a short time. 

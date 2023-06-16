# eTaxi
Credentials
Desktop app

    Administrator

    Username: admin@admin.com             
    Password: test12345

    Company user
    
    Username: kompanija@admin.com             
    Password: test12345

Mobile app

    User

    Username: user1@taxi.com  // Moguce jos login sa user[1,2,3,4,5,6]@taxi.com                        
    Password: test12345     

  
## Napomena
Seminarski je prijavljen u grupi za 2 osobe. Trenutno rad predaje samo jedan student IB180151. Ima nekih stvari u prijavi koje nisam uradio jer su bile za drugu osobu. Pokusao sam zadovoljiti sve sto je potrebno da rad bude dovoljan za jednu osobu.



Open a terminal inside the solution folder and use following commands :

    docker-compose build
    docker-compose up

To start the mobile app, from the root folder navigate to UI -> etaxi_mobile and run:

    flutter pub get
    flutter run

Stripe test card number:

    4242 4242 4242 4242

To start the desktop(admin) app, from the root folder navigate to UI -> etaxi_admin and run:

    flutter pub get
    flutter run


To be able to run the app your AVD needs to have Google Play Services because the project is using Google Maps and other Google services. 



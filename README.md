# app
Kurs ASP.NET Core - budowa aplikacji
1. Wprowadzenie
  1.1. Wstęp
  1.2. Omówienie materiałów
  1.3. Środowisko programistyczne
  1.4. Omówienie .NET Core
  1.5. Czym jest dotnet CLI
  1.6. Przykładowy projekt Web API
2. Rdzeń aplikacji
  2.1. Architektura aplikacji
  2.2. Zależności pomiędzy projektami
  2.3. Domena oraz encja
  2.4. Model użytkownika
  2.5. Model wydarzenia
  2.6. Model biletu
  2.7 Repozytorium
3. Od zera do kontrolera
  3.1. Implementacja repozytorium wydarzeń
  3.2. Implementacja repozytorium użytkowników
  3.3. Definicja serwisu aplikacji oraz DTO
  3.4. Implementacja serwisu aplikacji wydarzeń
  3.5. Biblioteka Automapper
  3.6. Wstrzykiwanie zależności
  3.7. Kontroler wydarzeń z przykładowymi danymi
4. Obsługa wydarzeń
  4.1. Tworzenie wydarzeń
  4.2. Dodawanie biletów
  4.3. Edycja wydarzeń
  4.4. Metody rozszerzające
  4.5. Usuwanie wydarzeń
  4.6. Szczegóły wydarzenia
  4.7. Wykonywanie zapytań HTTP z użyciem cURL
  4.8. Wykonywanie zapytań HTTP z użyciem Postman
5. Użytkownicy
  5.1. Rejestracja
  5.2. Logowanie
  5.3. JSON Web Tokens
  5.4. JWT w ASP.NET Core
  5.5. Ustawienia JWT
  5.6. Tworzenie własnych tokenów - część I
  5.7. Tworzenie własnych tokenów - część II
  5.8. Czas życia tokena - timestamp i standard EPOCH
  5.9. Operacja logowania z wykorzystaniem JWT
  5.10. Identyfikacja użytkownika
  5.11. Zabezpieczanie dostępu z atrybutem Authorize
  5.12. Polityka bezpieczeństwa z użyciem Policy
6. Obsługa biletów
  6.1. Rozbudowa modelu domenowego  Ticket
  6.2. Serwis aplikacji do obsługi biletów
  6.3. Kontroler API dla biletów
  6.4. Zakup oraz anulowanie biletów
  6.5. Pobieranie biletów użytkownika
  6.6. Rozszerzenie modelu DTO dla biletu
7. Infrastruktura i framework
  7.1. Finalne poprawki domenty
  7.2. Logowanie danych
  7.3. Logowanie danych z użyciem NLog
  7.4. Cache danych
  7.5. Autofac - zaawansowany kontener IoC
  7.6. Warunkowa inicjalizacja danych
  7.7. Własny middleware do obsługi wyjątków
8. Testowanie i wdrożenie
  8.1. Testy w .NET Core
  8.2. Stworzenie projektów z testami
  8.3. Pierwszy test jednostkowy
  8.4. Unit test z użyciem Moq i FluentAssertion
  8.5. Testy integracyjne w ASP.NET Core
  8.6. Publikowanie aplikacji w dotnet publish
  8.7. Konfiguracja serwera HTTP Nginx
  8.8. Zakończenie

describe("User should not be able to access Personal page without beeing logged in", () => {
  it("should not render anythin at /profile", () => {
    cy.visit("http://localhost:3000/profile");
    cy.contains("Användarprofil").should("not.exist");
    cy.contains("Min profil").should("not.exist");
  });

  it("should redirect to login page when trying to access quiz page without being logged in", () => {
    cy.visit("http://localhost:3000/profile/user1");

    cy.url().should("include", "/login");

    cy.get("form").should("be.visible");
    // Användaren skickas till home
    cy.url().should("include", "/");
  });
});

describe("User should be able to access Personal page when logged in", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.url().should("include", "/login");

      cy.get("form").should("be.visible");

      cy.get(":nth-child(2) > .login-input").type("breeder@breeder.breeder");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("Private1!");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      // Användaren skickas till home
      cy.url().should("include", "/");
      cy.wait(1000);

      // Kolla efter element som endast visas om man är innloggad
      cy.contains("Logga ut");
      cy.contains("Min profil");
    });
  });

  it("should be possible to se your profile information", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Min profil").click();
    cy.wait(1000);

    cy.contains("Min profil");
    cy.contains("breeder@breeder.breeder");
    cy.contains("Om mig");

    cy.contains("Organisationsnummer:");
    cy.contains("1122334449");

    cy.contains("Organisationsnamn:");
    cy.contains("Uppfödare AB");

    cy.contains("Affärskontakt:");
    cy.contains("Kalle P");

    cy.contains("Adress:");
    cy.contains("Uppfödargatan 3");

    cy.contains("Postnummer:");
    cy.contains("11122");

    cy.contains("Stad:");
    cy.contains("Swestad");

    // cy.contains("Telefonnummer");
    // cy.contains("0733101010");

    cy.contains("Mina dokument:");
    cy.get(":nth-child(8) > :nth-child(2) > div > img").should("exist");

    cy.contains("Recensioner");
    cy.contains("Inga recensioner.");
  });

  it("should be possible to change your profile information", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Min profil").click();
    cy.wait(1000);

    cy.contains("Min profil");
    cy.contains("breeder@breeder.breeder");

    cy.get(".pen-img").should("exist").click();

    cy.contains("Om mig");
    cy.get("textarea")
      .clear()
      .type("Uppfödare av fin fina hundar, prima deluxe!");
    cy.get(":nth-child(2) > input").clear().type("1234567890");

    // cy.contains("Organisationsnamn:");
    cy.get(":nth-child(3) > input").clear().type("Fin fina hundar AB");
    // cy.contains("Affärskontakt:");
    cy.get(":nth-child(4) > input").clear().type("Maja Persson");
    // cy.contains("Adress:");
    cy.get(":nth-child(5) > input").clear().type("Uppfödargatan 33");
    // cy.contains("Postnummer:");
    cy.get(":nth-child(6) > input").clear().type("29177");
    // cy.contains("Stad:");
    cy.get(":nth-child(7) > input").clear().type("Malmö");
    // cy.contains("Telefonnummer");
    // cy.contains("0733101010");

    cy.contains("Spara").click();
    cy.wait(2000);

    cy.contains("1234567890");
    cy.contains("Fin fina hundar AB");
    cy.contains("Maja Persson");
    cy.contains("Uppfödargatan 33");
    cy.contains("Postnummer:");
    cy.contains("29177");
    cy.contains("Malmö");

    cy.contains("Mina dokument:");
    cy.get(":nth-child(8) > :nth-child(2) > div > img").should("exist");

    cy.contains("Recensioner");
    cy.contains("Inga recensioner.");

    cy.get(".pen-img").should("exist").click();
    cy.contains("Avbryt").click();
    cy.wait(500);
    cy.contains("Avbryt").should("not.exist");
  });
});

describe("User be able to visit other profil pages", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.url().should("include", "/login");

      cy.get("form").should("be.visible");

      cy.get(":nth-child(2) > .login-input").type("breeder@breeder.breeder");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("Private1!");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      // Användaren skickas till home
      cy.url().should("include", "/");
      cy.wait(1000);

      // Kolla efter element som endast visas om man är innloggad
      cy.contains("Logga ut");
      cy.contains("Min profil");
    });
  });

  it("should be able to filter users based om is verified", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Sök profil").should("exist").click();
    cy.url().should("include", "/profileSearch");
    cy.wait(1000);

    cy.contains("Användarregister");

    cy.get(".user-list-item")
      .its("length")
      .then((beforeCount) => {
        cy.get("input").click();
        cy.wait(500);
        cy.get(".user-list-item")
          .its("length")
          .then((afterCount) => {
            expect(afterCount).to.be.lessThan(beforeCount);
          });
      });
  });

  it("should not be possible to change others profile information", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Sök profil").click();
    cy.url().should("include", "/profileSearch");
    cy.wait(1000);
    cy.contains("Användarregister");

    cy.contains("user1@example.com").click();

    cy.contains("user1@example.com");
    cy.contains("Verifierad");
    cy.contains("Användarprofil");
    cy.contains("Anmäl profil");
    cy.get(".pen-img").should("not.exist");
  });

  it("should be possible to write a review on breeders profiles", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Sök profil").click();
    cy.url().should("include", "/profileSearch");
    cy.wait(1000);
    cy.contains("Användarregister");

    cy.contains("user1@example.com").click();
    cy.wait(1000);

    cy.contains("user1@example.com");
    cy.contains("Recensioner");
    cy.get("ul > :nth-child(1)").should("exist");
    cy.contains("Lägg till en recension");

    cy.get("select").select("4");
    cy.get("textarea").type("Bästa uppfödaren i stan, trevligt bemötande!");
    cy.contains("Skicka Recension").click();
    cy.wait(2000);
    cy.get("ul > :nth-child(2)")
      .should(
        "contain",
        "Kommentar: Bästa uppfödaren i stan, trevligt bemötande!"
      )
      .should("contain", "Skriven av: breeder@breeder.breeder");
    cy.contains("Inga recensioner.").should("not.exist");
  });

  it("should be possible to file a complaint on breeders on their profile page", () => {
    cy.visit("http://localhost:3000");
    cy.contains("Sök profil").click();
    cy.url().should("include", "/profileSearch");
    cy.wait(1000);
    cy.contains("Användarregister");

    cy.contains("user1@example.com").click();

    cy.contains("user1@example.com");
    cy.contains("Anmäl profil").click();

    cy.get(".report-profile-modal").should("exist");
    cy.get(".input-report-container > textarea").type(
      "Högst otrevlig uppfödare och valparna är väldigt fula!"
    );
    cy.get(".report-profile-submit-button").click();
    cy.wait(500);
    cy.contains(
      "Högst otrevlig uppfödare och valparna är väldigt fula!"
    ).should("not.exist");
    cy.contains("Rapporten har skickats!").should("exist");

    cy.get(".report-profile-modal-close-btn").click();
    cy.get(".report-profile-modal").should("not.exist");
  });
});

describe("Home page should have serach functionality and adds", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.get(":nth-child(2) > .login-input").type("user1@example.com");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("user1*123");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      cy.wait(500);
      // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
      cy.url().should("include", "/");
    });
  });

  it("should get you to quiz when pressing the take quiz button when user is logged in", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000); // Vänta i 2 sekunder för autentisering
    cy.contains("Ta vårt quiz!").click();
    cy.contains("QUIZ");
    cy.contains("Vilket djur passar dig bäst?");
    cy.contains("Starta Quizet");
  });

  it("should have a functional searchbar", () => {
    cy.visit("http://localhost:3000");
    cy.wait(1000); // Vänta i 2 sekunder för autentisering
    cy.get(".bigAdContainer").should("exist");

    cy.get(".bigAdContainer")
      .its("length")
      .then((beforeCount) => {
        cy.get(".search").type("Hund");

        // Räkna antalet element efter filtrering
        cy.get(".bigAdContainer")
          .its("length")
          .then((afterCount) => {
            // Exempel på jämförelse
            expect(afterCount).to.be.lessThan(beforeCount);
          });
      });
  });

  it("should have a functional filter by Animal", () => {
    cy.visit("http://localhost:3000");

    const filterType = [
      "Hund",
      "Katt",
      "Fågel",
      "Gnagare",
      "Akvarium",
      "Reptil",
      "Alla",
    ];

    cy.wait(1000); // Vänta i 2 sekunder för autentisering
    cy.get(".bigAdContainer").should("exist");
    cy.get(".bigAdContainer")
      .its("length")
      .then((beforeCount) => {
        filterType.forEach((str) => {
          cy.contains(str).should("exist");

          //Ligger en div ovanför så behöver vara superspecifik
          cy.get(`select.filter-input[name="type"]`).select(`${str}`);
          cy.wait(500);

          cy.get("body").then(($body) => {
            // Kontrollera om .bigAdContainer finns på sidan
            const hasBigAdContainer = $body.find(".bigAdContainer").length > 0;
            if (hasBigAdContainer) {
              // Räkna antalet element efter filtrering
              cy.get(".bigAdContainer")
                .its("length")
                .then((afterCount) => {
                  // Exempel på jämförelse
                  if (str !== "Alla") {
                    expect(afterCount).to.be.lessThan(beforeCount);
                  } else expect(beforeCount).to.be.equal(afterCount);
                });
            } else {
              expect(beforeCount).to.be.greaterThan(0); // Exempel på jämförelse
            }
          });
        });
      });
  });

  it("should have a functional filter by sex", () => {
    cy.visit("http://localhost:3000");

    const filterType = ["Hona", "Hane", "Båda"];
    let count = 0;

    cy.wait(1000); // Vänta i 2 sekunder för autentisering
    cy.get(".bigAdContainer").should("exist");
    cy.get(".bigAdContainer")
      .its("length")
      .then((beforeCount) => {
        filterType.forEach((str) => {
          cy.contains(str).should("exist");

          //Ligger en div ovanför så behöver vara superspecifik
          cy.get(`select.filter-input[name="gender"]`).select(`${str}`);
          cy.wait(500);

          cy.get("body").then(($body) => {
            // Kontrollera om .bigAdContainer finns på sidan
            const countBigAdContainer = $body.find(".bigAdContainer").length;
            if (countBigAdContainer > 0) {
              for (let i = 1; countBigAdContainer >= i; i++) {
                cy.get(`:nth-child(${i}) > .bigAdSide > :nth-child(2)`).should(
                  "contain",
                  `Kön: ${str}` || "Kön: Båda"
                );
              }

              // Räkna antalet element efter filtrering
              cy.get(".bigAdContainer")
                .its("length")
                .then((afterCount) => {
                  // Exempel på jämförelse
                  if (str !== "Båda") {
                    expect(afterCount).to.be.lessThan(beforeCount);
                  } else expect(beforeCount).to.be.equal(afterCount);
                });
            } else {
              expect(beforeCount).to.be.greaterThan(0); // Exempel på jämförelse
            }
          });
        });
      });
  });
});

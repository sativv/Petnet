import React from "react";
import FAQSubject from "../components/FAQSubject";

function ContactFAQ() {
  return (
    <div>
      <h3>Vanliga frågor</h3>

      <FAQSubject title={"Hur köper jag ett husdjur på marknadsplatsen?"}>
        För att köpa ett husdjur, bläddra bland de tillgängliga annonserna, välj
        ett husdjur och klicka på "Köp nu" eller "Kontakta säljare". Du kan
        sedan arrangera detaljer som betalning, leverans eller upphämtning
        direkt med säljaren.
      </FAQSubject>
      <FAQSubject title={"Kan jag lita på säljarna på denna plattform?"}>
        Vi tar säljarverifiering på allvar. Även om de flesta säljare är
        pålitliga, uppmuntrar vi köpare att läsa recensioner, ställa frågor och
        verifiera detaljer innan de gör ett köp. Vårt team granskar också
        regelbundet annonser för att säkerställa att de följer våra standarder.
      </FAQSubject>
      <FAQSubject title={"Vilka betalningsmetoder accepteras?"}>
        Betalningar arrangeras vanligtvis direkt mellan köpare och säljare. Vi
        rekommenderar att använda säkra betalningsmetoder som PayPal,
        banköverföringar eller andra betrodda plattformar för att säkerställa
        att båda parter är skyddade.
      </FAQSubject>

      <FAQSubject
        title={"Varför tar det så lång tid att registrera mig som uppfödare?"}
      >
        är du registrerar dig som uppfödare krävs det att någon av våra
        medarbetare går igenom alla dina uppgifter samt registreringsbevis.
        Detta tar ibland lite tid och vi ber er därför om tålamod. Om du tror
        något misstag har hänt eller det tar för lång tid, var god ta kontakt
        med vår support.
      </FAQSubject>
      <FAQSubject title={"Hur lägger jag upp ett husdjur till salu?"}>
        För att lägga upp ett husdjur till salu, skapa ett konto, klicka på
        "Lägg upp annons" och fyll i den nödvändiga informationen om husdjuret.
        Var noga med att inkludera tydliga bilder, korrekta beskrivningar och
        eventuell relevant dokumentation.
      </FAQSubject>
      <FAQSubject
        title={"Vad ska jag göra om jag stöter på en bedräglig annons?"}
      >
        Om du tror att en annons är bedräglig eller misstänkt, rapportera den
        omedelbart med "Rapportera"-knappen på annonssidan. Vårt team kommer att
        undersöka och vidta lämpliga åtgärder.
      </FAQSubject>
      <FAQSubject
        title={"Erbjuder ni några garantier för husdjuren som listas?"}
      >
        Eftersom vår plattform kopplar samman köpare och säljare erbjuder vi
        inga garantier för de listade husdjuren. Vi uppmuntrar dock tydlig
        kommunikation mellan köpare och säljare för att säkerställa transparens
        och nöjdhet på båda sidor.
      </FAQSubject>
      <FAQSubject title={"Hur kontaktar jag kundsupport?"}>
        Du kan nå vårt kundsupportteam via "Kontakta oss"-sidan eller genom att
        mejla oss på mailen ni finner nedan. Vi strävar efter att svara på alla
        förfrågningar inom 24-48 timmar.
      </FAQSubject>
      <FAQSubject
        title={"Finns det några avgifter för att använda marknadsplatsen?"}
      >
        Att skapa ett konto och bläddra bland annonser är gratis. Det kan dock
        förekomma annonseringsavgifter för säljare, och premiumfunktioner kan
        vara tillgängliga mot en extra kostnad.
      </FAQSubject>

      <h3>Kontakta oss</h3>
      <p>Tel: 0000 00 00 00</p>
      <p>Mail: Contact@Petnet.se</p>
    </div>
  );
}

export default ContactFAQ;

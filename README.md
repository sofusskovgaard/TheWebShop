# TheWebShop

- [TheWebShop](#thewebshop)
  - [Formål](#formål)
  - [Mål](#mål)
  - [Krav](#krav)
    - [Forsiden](#forsiden)
    - [Varekurven](#varekurven)
    - [Checkout](#checkout)
    - [Optionelle krav til applikationen](#optionelle-krav-til-applikationen)
    - [Andre krav til design og implementation](#andre-krav-til-design-og-implementation)

## Formål

At demonstrere at man opfylder faget "Databaseprogrammering III" målpinde. Herunder at vise at man kan designe, programmere og teste en database model, som vil kunne opfylde kravene til projektet.

## Mål

- At brugeren via en webapplication (der udvikles senere) kan browse rundt mellem nogle varer, lægge dem i kurven, registrere sig og simulere et køb.
- At Data-laget er opbygget efter best practice for database design.

## Krav

Følgende krav til den færdige applikation benyttes til at udlede en database model.

### Forsiden

- [ ] Forsiden viser et antal produkter med et billede af hver, prisen, navn og en knap til at lægge varen i kurven
- [ ] Der benyttes Paging således at forsiden kun viser et bestemt antal produkter ad gangen. Man kan se at der evt. er flere produkter
- [ ] Der er mulighed for at søge på "Brand" og på "Type" eller lignende
- [ ] Der er også fritekst-søgning
- [ ] Der er mulighed for stigende og faldende sortering
- [ ] Der vises et ikon med en varekurv og et antal varer i kurven. Klikkes på ikonet, vises varekurven
- [ ] Lægges en vare i kurven, vises den opdaterede varekurv

### Varekurven

- [ ] Varekurven viser en opdateret liste af valgte produkter, med billede, navn, styk-pris, antal (skal kunne ændres) samt linjepriseen.
- [ ] Der skal være en Update knap, som opdaterer priserne hvis man ændrer antallet.
- [ ] Det skal være muligt at fjerne et produkt fra varekurven, hvis man fortryder valget
- [ ] Der skal være en Checkout knap, som fører til Checkout-siden
- [ ] Der skal være en knap, der giver mulighed for at fortsætte med at handle, inden man går til checkout

### Checkout

- [ ] Brugeren skal afgive oplysninger om email, navn, adresse, valg af betalingsmiddel og forsendelse
- [ ] Når brugeren trykke på Køb knappen, skal der udsendes en mail som bekræftelse af købet

### Optionelle krav til applikationen

- [ ] Forsiden viser "featured" produkter
- [ ] Når musen passerer henover et billede af et produkt, fremhæves billedet (evt. med en skygge eller ramme)
- [ ] Mulighed for at logge ind, f.eks. når man går til Checkout.
- [ ] Hvis brugeren er logget ind, slipper brugeren for at registrere sig igen
- [ ] Når brugeren er logget ind, vises produkter som anses for at være interessante for netop denne kunde, baseret på en profil
- [ ] En Admin side, der giver en administrator en liste over alle produkter og mulighed for at redigere produkterne.

### Andre krav til design og implementation

- [ ] Designet laves således at det opfylder best practice indenfor databasedesign
- [ ] Der benyttes Entity Framework Core
- [ ] Der foretages en funktionstest, der viser at de funktionelle krav er opfyldt

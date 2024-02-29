SOLPYME.Saml2 Servicios
==============================

Los servicios de autenticación de SOLPYME son un par de módulos http que agregan soporte SAML2P a los sitios web IIS, lo que permite que el sitio web actúe 
como un proveedor de servicios (SP) SAML2.

## Saml2AuthenticationModule
Saml2AuthenticationModule sigue el modelo de WSFederationAuthenticationModule para proporcionar autenticación Saml2 a sitios web IIS. En muchos casos, simplemente debe configurarse y funcionar sin ningún código escrito en la aplicación (aunque es necesario proporcionar un ClaimsAuthenticationModule propio para la traducción de reclamos).
muy recomendable).

## SlidingExpirationSessionAuthenticationModule
El SlidingExpirationSessionAuthenticationModule es una ventaja, agrega caducidad deslizante a las sesiones tal como funciona FormsAuthentication de forma inmediata.
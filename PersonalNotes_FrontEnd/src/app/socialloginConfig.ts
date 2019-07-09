import {
  SocialLoginModule,
  AuthServiceConfig,
  GoogleLoginProvider
} from 'angularx-social-login';

export function getAuthServiceConfigs(): AuthServiceConfig {
  debugger;
  let config = new AuthServiceConfig([
    {
      id: GoogleLoginProvider.PROVIDER_ID,
      provider: new GoogleLoginProvider('512127873037-3nhdiv7hnp1tfpt2b3o3jbgip50kaoj4.apps.googleusercontent.com')
    }
  ]);

  return config;
}

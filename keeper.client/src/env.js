export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:5001' : ''
export const useSockets = false
export const domain = 'nicksondrup.us.auth0.com'
export const clientId = 'hVd9w3Xzqs53QqEvgQpxneB6nmDG4w2r'
export const audience = 'https://studentauth.com'
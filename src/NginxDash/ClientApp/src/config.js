const development = !process.env.NODE_ENV || process.env.NODE_ENV === 'development';
const api_endpoint = "/_api";
const apiUrlPro = "/";
const apiUrlDev = "http://docker.loc:5080";

export const config = {
    development,
    loginItem: "user",
    homePath: development ? "" : "",
    apiUrl: (development ? apiUrlDev : apiUrlPro) + api_endpoint
};

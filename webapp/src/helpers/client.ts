import axios from "axios";
import { APIURL } from "../constants";

const solicitudApi = axios.create({
    baseURL: APIURL
});

solicitudApi.defaults.headers.common["Authorization"] = "Bearer " + localStorage.getItem("token");

export { solicitudApi };
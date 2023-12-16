import { useEffect, useState } from "react"
import axios from "axios";
import { APIURL } from "../../../constants";
import { ITipoSolicitud } from "../interface/ITipoSolicitud";
import { TipoSolicitudTable } from "../components/TipoSolicitudTable";

export const TipoSolicitudPage = () => {
    const [tiposSolicitud, setTiposSolicitud] = useState<ITipoSolicitud[]>([]);
    const [tipo, setTipo] = useState<string>("");

    const obtenerTipoSolicitudes = async () => {
        try {
            const request = await axios.get<ITipoSolicitud[]>(`${APIURL}/api/solicitud/tipos`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setTiposSolicitud(request.data);
        } catch (err) {

        }
    }

    const crearTipoSolicitud = async () => {
        try {
            if (tipo === "") {
                alert("favor ingresar el tipo de solicitud");
                return;
            }

            const request = await axios.post<ITipoSolicitud>(`${APIURL}/api/solicitud/tipos`, { tipo }, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setTiposSolicitud((prev) => [...prev, request.data]);
            setTipo("");
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerTipoSolicitudes();
    }, []);

    return (
        <>
            <div style={{ display: "flex", justifyContent: "space-evenly", marginBottom: 50, marginTop: 50 }}>

                <label className="sr-only">Tipo Solicitud </label>
                <input type="text" className="form-control" onChange={(e) => setTipo(e.target.value)} value={tipo} />

                <button className="btn btn-success" onClick={() => crearTipoSolicitud()}>Crear</button>
            </div>
            <TipoSolicitudTable tipoSolicitudes={tiposSolicitud} />
        </>
    )
}
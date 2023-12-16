import { FC } from "react";
import { ISolicitud } from "../interface/ISolicitud";


export const SolicitudTable: FC<{ solicitudes: ISolicitud[], estado: 'Pendiente' | 'Aprobado' | 'Cancelado' }> = ({ solicitudes, estado }) => {

    const tipoBadge = () => {
        let tipo = "";

        switch (estado) {
            case 'Aprobado':
                tipo = "badge bg-success";
                break;
            case 'Cancelado':
                tipo = "badge bg-danger";
                break;
            case 'Pendiente':
                tipo = "badge bg-warning";
                break;
            default:
                tipo = "badge bg-warning";
                break;
        }

        return tipo;
    }

    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Usuario</th>
                    <th>Estado</th>
                    <th>Tipo</th>
                    <th>Zona</th>
                </tr>
            </thead>
            <tbody>
                {solicitudes.map((u) => (
                    <tr key={u.id}>
                        <td>{u.descripcion}</td>
                        <td>{u.usuario}</td>
                        <td><span className={tipoBadge()}>{u.estadoSolicitud}</span></td>
                        <td>{u.tipoSolicitud}</td>
                        <td>{u.zona}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}
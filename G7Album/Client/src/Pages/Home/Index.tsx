import { useEffect } from "react";
import { useGlobalContext } from "../../Context/useGlobalContext";
import { UserModels } from "../../Models/User.models";
import { getStorage } from "../../Utils/updateStorage";

export const Home : React.FC = () => {
    const storeGlobal = useGlobalContext();

    useEffect(() => {
        console.log("AAAAASD", getStorage<UserModels>("User"))
    }, [])


    return (
        <div>

            <p>ESTO ES EL HOME</p>

            <p>{JSON.stringify(storeGlobal.GetMyUserData())}</p>

        </div>

    )
}
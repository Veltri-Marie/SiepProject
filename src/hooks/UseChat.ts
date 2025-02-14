import { SetStateAction, useState} from "react";
import jobService from "../services/JobService.ts";

export default function useChat() {
    const [id, setId] = useState<number>(0);
    const [metier, setMetier] = useState("");
    const [description, setDescription] = useState("");
    const [knowHow, setKnowHow] = useState<string[]>([]);
    const [error, setError] = useState("");

    const handleChange = (e: { target: { value: SetStateAction<string>; }; }) => {
        setMetier(e.target.value);
    };

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        try {
            const data = await jobService.getMetiers(metier);
            setDescription(data.description);
            setKnowHow(data.knowHows)
            setId(data.id);
            setError("");
        } catch (err) {
            setError("Métier non trouvé ou erreur serveur.");
            setDescription("");
        }
    };

    return { id, metier, description, knowHows: knowHow, error, handleChange, handleSubmit };
}

import { useState } from "react";

const useSearch = (initialValue: string = "") => {
    const [value, setValue] = useState(initialValue);
    const [isFocused, setIsFocused] = useState(false);

    const handleSubmit = async (e: React.FormEvent, fetchMetier: (name: string) => Promise<void>) => {
        e.preventDefault();
        if (value.trim()) {
            await fetchMetier(value);
        }
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValue(e.target.value);
    };

    const handleFocus = () => setIsFocused(true);
    const handleBlur = () => setIsFocused(false);

    return {
        value,
        isFocused,
        handleSubmit,
        handleChange,
        handleFocus,
        handleBlur,
    };
};

export default useSearch;

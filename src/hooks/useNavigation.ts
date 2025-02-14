import { useState } from "react";
import { useNavigate } from "react-router-dom";

const useNavigation = (initialIndex: number) => {
    const [selectedIndex, setSelectedIndex] = useState<number>(initialIndex);
    const navigate = useNavigate();

    const handleNavigation = (index: number, path: string) => {
        setSelectedIndex(index);
        navigate(path);
    };

    return {
        selectedIndex,
        handleNavigation
    };
};

export default useNavigation;

import React, { useEffect, useRef } from "react";
import Quill from "quill";
import "quill/dist/quill.snow.css";
import { Box, Typography } from "@mui/material";
import { DtoJob } from "../../Dtos/DtoJob.ts";

interface JobEditorProps {
    jobData: DtoJob | undefined;
    setJobData: (value: DtoJob) => void;
}

const JobEditor: React.FC<JobEditorProps> = ({ jobData, setJobData }) => {
    const descriptionRef = useRef<HTMLDivElement | null>(null);
    const knowHowsRef = useRef<HTMLDivElement | null>(null);
    const quillDescriptionRef = useRef<Quill | null>(null);
    const quillKnowHowsRef = useRef<Quill | null>(null);

    useEffect(() => {
        if (descriptionRef.current && !quillDescriptionRef.current) {
            quillDescriptionRef.current = new Quill(descriptionRef.current, {
                theme: "snow",
                placeholder: "Éditez la description ici...",
                modules: {
                    toolbar: [
                        [{ header: [1, 2, 3, false] }],
                        ["bold", "italic", "underline", "strike"],
                        [{ list: "ordered" }, { list: "bullet" }],
                        ["blockquote", "code-block"],
                    ],
                },
            });

            quillDescriptionRef.current.on("text-change", () => {
                if (jobData) {
                    setJobData({ ...jobData, description: quillDescriptionRef.current?.root.innerHTML || "" });
                }
            });
        }

        if (knowHowsRef.current && !quillKnowHowsRef.current) {
            quillKnowHowsRef.current = new Quill(knowHowsRef.current, {
                theme: "snow",
                placeholder: "Éditez le savoir-faire ici...",
                modules: {
                    toolbar: [
                        [{ header: [1, 2, 3, false] }],
                        ["bold", "italic", "underline", "strike"],
                        [{ list: "ordered" }, { list: "bullet" }],
                        ["blockquote", "code-block"],
                    ],
                },
            });

            quillKnowHowsRef.current.on("text-change", () => {
                if (jobData) {
                    setJobData({ ...jobData, knowHows: [quillKnowHowsRef.current?.root.innerHTML || ""] });
                }
            });
        }

        if (jobData?.description && quillDescriptionRef.current) {
            const currentDescription = quillDescriptionRef.current.root.innerHTML;
            if (currentDescription !== jobData.description) {
                quillDescriptionRef.current.root.innerHTML = jobData.description;
            }
        }

        if (jobData?.knowHows?.length && quillKnowHowsRef.current) {
            const currentKnowHows = quillKnowHowsRef.current.root.innerHTML;
            if (currentKnowHows !== jobData.knowHows[0]) {
                quillKnowHowsRef.current.root.innerHTML = jobData.knowHows[0];
            }
        }
    }, [jobData, setJobData]);

    return (
        <Box sx={{ width: "100%", display: "flex", flexDirection: "column", gap: 3, mt: 2 }}>
            <Box
                sx={{
                    width: "100%",
                    maxWidth: "1200px",
                    height: "400px",
                    backgroundColor: "#fff",
                    border: "1px solid #ccc",
                    borderRadius: "8px",
                    padding: 2,
                    boxShadow: "0px 4px 8px rgba(0, 0, 0, 0.1)",
                    alignSelf: "center",
                    display: "flex",
                    flexDirection: "column",
                    overflow: "hidden",
                }}
            >
                <Typography variant="h6" sx={{ marginBottom: 1 }}>Description</Typography>
                <div ref={descriptionRef} style={{ flex: 1, maxHeight: "300px", overflow: "auto" }} />
            </Box>

            <Box
                sx={{
                    width: "100%",
                    maxWidth: "1200px",
                    height: "400px",
                    backgroundColor: "#fff",
                    border: "1px solid #ccc",
                    borderRadius: "8px",
                    padding: 2,
                    boxShadow: "0px 4px 8px rgba(0, 0, 0, 0.1)",
                    alignSelf: "center",
                    display: "flex",
                    flexDirection: "column",
                    overflow: "hidden",
                }}
            >
                <Typography variant="h6" sx={{ marginBottom: 1 }}>Savoir-Faire</Typography>
                <div ref={knowHowsRef} style={{ flex: 1, maxHeight: "300px", overflow: "auto" }} />
            </Box>
        </Box>
    );
};

export default JobEditor;

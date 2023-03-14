import { toast } from 'react-toastify';
var toastJs = {
    success (msg,autoClose = 5000 , hideProgressBar = false , closeOnclick = true , pauseOnHover = true , draggable = true , progress = undefined) {
        toast.success(msg, {
            position: "top-right",
            autoClose: autoClose,
            hideProgressBar: hideProgressBar,
            closeOnClick: closeOnclick,
            pauseOnHover: pauseOnHover,
            draggable: draggable,
            progress: progress,
            });
    },
    error (msg,autoClose = 5000 , hideProgressBar = false , closeOnclick = true , pauseOnHover = true , draggable = true , progress = undefined) {
        toast.error(msg, {
            position: "top-right",
            autoClose: autoClose,
            hideProgressBar: hideProgressBar,
            closeOnClick: closeOnclick,
            pauseOnHover: pauseOnHover,
            draggable: draggable,
            progress: progress,
            });
    },
    warning (msg,autoClose = 5000 , hideProgressBar = false , closeOnclick = true , pauseOnHover = true , draggable = true , progress = undefined) {
        toast.warning(msg, {
            position: "top-right",
            autoClose: autoClose,
            hideProgressBar: hideProgressBar,
            closeOnClick: closeOnclick,
            pauseOnHover: pauseOnHover,
            draggable: draggable,
            progress: progress,
            });
    }
} 
export default toastJs ; 